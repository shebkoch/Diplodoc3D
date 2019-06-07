using System;
using ECS.Component.Creatures;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static System.Single;

namespace ECS.System
{
	public class RotationSystem : JobComponentSystem
	{
		[BurstCompile]
		struct Job : IJobForEach<MovingComponent, Rotation>
		{
			//TODO : add freezing component
			public void Execute([ReadOnly] ref MovingComponent movingComponent, ref Rotation rotation)
			{
				float horizontal = movingComponent.horizontal;
				float vertical = movingComponent.vertical;
			
				if(Math.Abs(horizontal) < Epsilon && Math.Abs(vertical) < Epsilon) return;
				
				rotation.Value = quaternion.LookRotation(new float3(horizontal,0 ,vertical+0.001f), math.up());
			}
		}

		protected override JobHandle OnUpdate(JobHandle inputDependencies)
		{
			var job = new Job()
			{
			};

			return job.Schedule(this, inputDependencies);
		}
	}
}