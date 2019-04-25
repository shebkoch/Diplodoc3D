using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Artifacts.Common;
using ECS.Component.Creatures;
using ECS.Component.Flags;
using ECS.Component.Modificators;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Artifacts
{
	
	public class StoneGazeArtifactSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			float lastUse = 0;
			bool isCasting = false;
			bool enable = false;
			float currentTime = Time.realtimeSinceStartup;
			float duration = 0;
			float radius = 0;

			float3 playerPos = GetSingleton<PlayerPosition>().position;

			Entities.ForEach((Entity e,
				ref StoneGazeArtifact stoneGazeArtifact,
				ref ArtifactUsingComponent artifactUsingComponent,
				ref CooldownComponent cooldownComponent,
				ref RadiusComponent radiusComponent,
				ref DurationComponent durationComponent) =>
			{
				bool isCastNeeded = artifactUsingComponent.isCastNeeded;
				enable = cooldownComponent.canUse;
				duration = durationComponent.duration;
				radius = radiusComponent.radius;
				if (isCastNeeded && enable)
				{
					lastUse = currentTime;
					isCasting = true;
					enable = false;
				}
				
				cooldownComponent.canUse = enable;
				if(lastUse != 0)
					cooldownComponent.isReloadNeeded = true;
			});
			
			if (isCasting)
			{
				Entities.ForEach((Entity e,
					ref EnemyTag enemyComponent,
					ref StunModificatorComponent stunModificatorComponent) =>
				{
					stunModificatorComponent.last = lastUse;
					stunModificatorComponent.duration = duration;
					stunModificatorComponent.isEnable = true;
				});
			}
		}

	}
}