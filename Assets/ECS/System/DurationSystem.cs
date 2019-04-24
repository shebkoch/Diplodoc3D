using ECS.Component;
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
	public class DurationSystem : JobComponentSystem
	{
		[BurstCompile]
		struct Job : IJobForEach<DurationComponent>
		{
			public float realtimeSinceStartup;
			public void Execute(ref DurationComponent durationComponent)
			{
				bool isStartNeeded = durationComponent.isStartNeeded;
				bool isEnd = durationComponent.isEnd;
				float duration = durationComponent.duration;
				float last = durationComponent.last;
				float currentTime = realtimeSinceStartup;

				if (isStartNeeded)
				{
					last = currentTime;
					durationComponent.last = last;
					durationComponent.isStartNeeded = false;
					durationComponent.isEnd = false;
				}
				
				if (isEnd || last + duration > currentTime) return;

				durationComponent.isEnd = true;
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