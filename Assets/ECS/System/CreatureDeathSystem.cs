using ECS.Component;
using ECS.Component.Creatures;
using ECS.Component.Damage;
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
[DisableAutoCreation]	public class CreatureDeathSystem : JobComponentSystem
	{
		[BurstCompile]
		struct Job : IJobForEach<ParametersComponent, DeathComponent>
		{
			public void Execute(ref ParametersComponent parametersComponent, ref DeathComponent deathComponent)
			{
				deathComponent.isDeathNeed = parametersComponent.health <= 0;
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