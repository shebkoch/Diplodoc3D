using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Artifacts.Common;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Artifacts
{
	public class SlowDownArtifactSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			
			Entities.ForEach((Entity e,
				ref SlowDownArtifact slowDownArtifact,
				ref DurationComponent durationComponent,
				ref ArtifactUsingComponent artifactUsingComponent,
				ref CooldownComponent cooldownComponent) =>
			{
				bool canUse = artifactUsingComponent.canUse;
				bool isEnd = durationComponent.isEnd;
				if (canUse)
				{
					Time.timeScale = slowDownArtifact.slow;
					cooldownComponent.isReloadNeeded = true;
					artifactUsingComponent.canUse = false;
					durationComponent.isStartNeeded = true;
				}

				if (isEnd)
				{
					Time.timeScale = 1;
				}
			
			});
//			float radius = 0;
//			float slow = 0;
//			bool isChanged = false;
//			foreach (Artifact entity in GetEntities<Artifact>())
//			{
//				var canUse = artifactUsingComponent.canUse;
//				radius = radiusComponent.radius;
//				slow = slowDownArtifact.slow;
//				bool isEnd = durationComponent.isEnd;
//				bool active = slowDownArtifact.active;
//				if (isEnd && active)
//				{
//					isChanged = true;
//					slow = -slow;
//					active = false;
//				}
//				if (canUse)
//				{
//					isChanged = true;
//					durationComponent.isStartNeeded = true;
//					cooldownComponent.isReloadNeeded = true;
//					active = true;
//				}
//				slowDownArtifact.active = active;
//			}
//
//			if(!isChanged) return;
//			
//			foreach (var entity in GetEntities<Enemy>())
//			{
//				float distanceToPlayer = playerFollowComponent.distanceToPlayer;
//				if(math.abs(distanceToPlayer) > math.abs(radius)) continue;
//
//				float speed = movingComponent.speed;
//				speed += slow;
//				movingComponent.speed = speed;
//			}
		}
	}
}