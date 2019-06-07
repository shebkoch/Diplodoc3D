using ECS.Component.Creatures;
using ECS.Component.Damage;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;

namespace ECS.System
{
	public class CreatureDeathSystem : JobComponentSystem
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