using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Artifacts.Common;
using ECS.Component.Flags;
using ECS.Component.Modificators;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Artifacts
{
	
[DisableAutoCreation]	public class StoneGazeArtifactSystem : ComponentSystem
	{
		protected struct Artifact
		{
			public StoneGazeArtifact stoneGazeArtifact;
			public ArtifactUsingComponent artifactUsingComponent;
			public CooldownComponent cooldownComponent;
		}

		protected struct Enemy
		{
			public EnemyTag enemyTag;
			public StunModificatorComponent stunModificatorComponent;
		}

		protected override void OnUpdate()
		{
			float lastUse = 0;
			bool isCasting = false;
			bool enable = false;
			float currentTime = Time.realtimeSinceStartup;
			float duration = 0;
			float3 playerPos = new float3();
			float radius = 0;

			Entities.ForEach((Entity e,
				ref StoneGazeArtifact stoneGazeArtifact,
				ref ArtifactUsingComponent artifactUsingComponent,
				ref CooldownComponent cooldownComponent) =>
			{
				bool isCastNeeded = artifactUsingComponent.isCastNeeded;
				enable = cooldownComponent.canUse;
				duration = stoneGazeArtifact.duration;
				radius = stoneGazeArtifact.radius;
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