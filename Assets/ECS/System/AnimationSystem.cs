using ECS.Component.Creatures;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

namespace ECS.System
{
	public class AnimationSystem : JobComponentSystem
	{
		[BurstCompile]
		struct Job : IJobForEach<AnimatorComponent, MovingComponent>
		{
			public void Execute(ref AnimatorComponent animatorComponent, ref MovingComponent movingComponent)
			{
				animatorComponent.run = math.any(new float2(movingComponent.vertical, movingComponent.horizontal));
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