using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Artifacts.Common;
using ECS.Component.Creatures;
using ECS.Component.Flags;
using ECS.Component.Relations;
using ECS.System.Relations;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ECS.System.Artifacts
{
	[UpdateAfter(typeof(PlayerFollowSystem))]
[DisableAutoCreation]	public class FakePlayerFollowSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			
			float2 min = 0;
			float2 max = 0;
			bool isEnable = false;
			Entities.ForEach((Entity e,
				ref FakePlayerFollowArtifact fakePlayerFollowArtifact,
				ref ArtifactUsingComponent artifactUsingComponent,
				ref DurationComponent durationComponent,
				ref CooldownComponent cooldownComponent) =>
			{
				min = fakePlayerFollowArtifact.min;
				max = fakePlayerFollowArtifact.max;
				if (artifactUsingComponent.canUse)
				{
					durationComponent.isStartNeeded = true;
					cooldownComponent.isReloadNeeded = true;
					artifactUsingComponent.canUse = false;
				}
				isEnable = !durationComponent.isEnd;
			});
			if(!isEnable) return;
			
			Entities.ForEach((Entity e,
				ref EnemyTag enemyTag,
				ref PlayerFollowComponent playerFollowComponent,
				ref Translation translation,
				ref MovingComponent movingComponent) =>
			{
			
				float3 enemyPosition = translation.Value;
				float horizontal = 0;
				float vertical = 0;
				
				float2 result = math.normalize(new float2(Random.Range(min.x,max.x), Random.Range(min.y,max.y)) - enemyPosition.xy);
				horizontal = result.x;
				vertical = result.y;
				
				movingComponent.vertical = vertical;
				movingComponent.horizontal = horizontal;
			});

		}
	}
}