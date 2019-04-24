using ECS.Component;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace ECS.System
{
	public class CooldownJobSystem : JobComponentSystem
	{
		[BurstCompile]
		struct Job : IJobForEach<CooldownComponent>
		{
			public float realtimeSinceStartup;
			public void Execute(ref CooldownComponent cooldownComponent)
			{
				bool isReloadNeeded = cooldownComponent.isReloadNeeded;
				bool canUse = cooldownComponent.canUse;
				float cooldown = cooldownComponent.cooldown;
				float last = cooldownComponent.last;
				float currentTime = realtimeSinceStartup;

				if (isReloadNeeded)
				{
					last = currentTime;
					cooldownComponent.last = last;
					cooldownComponent.isReloadNeeded = false;
					cooldownComponent.canUse = false;
				}
				
				if (canUse || last + cooldown > currentTime) return;

				cooldownComponent.canUse = true;
			}
		}

		protected override JobHandle OnUpdate(JobHandle inputDependencies)
		{
			var job = new Job()
			{
				realtimeSinceStartup = Time.realtimeSinceStartup
			};

			return job.Schedule(this, inputDependencies);
		}
	}
}