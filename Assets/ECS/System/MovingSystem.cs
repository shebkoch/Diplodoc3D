
using ECS.Component;
using ECS.Component.Creatures;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace ECS.System
{
//	[UpdateAfter(typeof(UnityEngine.Experimental.PlayerLoop.FixedUpdate))]
	public class MovingSystem : JobComponentSystem
	{
		[BurstCompile]
		struct Job : IJobForEach<MovingComponent, Translation>
		{
			public float deltaTime;
			public void Execute([ReadOnly] ref MovingComponent movingComponent,  ref Translation translation)
			{
				translation.Value += new float3(movingComponent.horizontal, 0, movingComponent.vertical)
				                     * movingComponent.speed 
				                     * deltaTime;
			}
		}
		protected override JobHandle OnUpdate(JobHandle inputDependencies)
		{
			var job = new Job()
			{
				deltaTime = Time.deltaTime
			};
    
			return job.Schedule(this, inputDependencies);
		}
	}
}