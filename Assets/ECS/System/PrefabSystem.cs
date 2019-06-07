using System;
using ECS.Component;
using ECS.Component.Creatures;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using Random = Unity.Mathematics.Random;

namespace ECS.System
{
	public class PrefabSystem : JobComponentSystem
	{
		private EndSimulationEntityCommandBufferSystem barrier;
		
		protected override void OnCreate()
		{
			barrier = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
		}
		struct Job : IJobForEachWithEntity<PrefabComponent,MovingComponent, Translation>
		{
			public EntityCommandBuffer.Concurrent commandBuffer;
			public Random random;
				
			public void Execute(Entity entity, int index, [ReadOnly] ref PrefabComponent prefabComponent, ref MovingComponent movingComponent, ref Translation translation)
			{	
				//TODO remove if
				float3 position = prefabComponent.position;
				if (prefabComponent.needSpread)
				{
					float2 circleNormalized = random.NextFloat2Direction();
					position = new float3(circleNormalized.x, position.y, circleNormalized.y) * (prefabComponent.radius + 
					                                                                            random.NextFloat(prefabComponent.positionSpread.x,prefabComponent.positionSpread.y)) + position;
				}
				translation.Value = position;

				if (prefabComponent.needMovingComponent)
				{
					movingComponent.speed = prefabComponent.speed;
					movingComponent.vertical = prefabComponent.direction.y;
					movingComponent.horizontal = prefabComponent.direction.x;
				}
				commandBuffer.RemoveComponent<PrefabComponent>(index,entity);
			}
		}

		protected override JobHandle OnUpdate(JobHandle inputDependencies)
		{
			var job = new Job()
			{
				commandBuffer = barrier.CreateCommandBuffer().ToConcurrent(),
				random = new Random((uint) DateTime.Now.Ticks)
			};

			return job.Schedule(this, inputDependencies);
		}
	}
}