using ECS.Component;
using ECS.Component.Creatures;
using ECS.Component.Flags;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ECS.System
{
	public class PlayerPositionSystem : JobComponentSystem
	{
		[BurstCompile]
		struct Job : IJobForEach<PlayerPosition, PlayerTag, Translation>
		{
			public void Execute(ref PlayerPosition playerPosition, ref PlayerTag playerTag, ref Translation translation)
			{
				playerPosition.position = translation.Value;
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
