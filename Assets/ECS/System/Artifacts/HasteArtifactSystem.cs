using System;
using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Artifacts.Util;
using ECS.Component.Creatures;
using ECS.Component.Flags;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Artifacts
{
[DisableAutoCreation]	public class HasteArtifactSystem : ComponentSystem
	{
		protected struct Artifact
		{
			
		}
		protected struct Camera
		{
			
		}
		protected struct Player
		{
			public PlayerTag playerTag;
			public MovingComponent movingComponent;
		}
		protected override void OnUpdate()
		{
			bool isActive = false;
			float hasteSpeed = 0;
			bool isSpeedChange = false;
			Entities.ForEach((Entity e,
				ref ChanceByHpLoseComponent chanceByHpLoseComponent,
				ref HasteArtifact hasteArtifact,
				ref CooldownComponent cooldownComponent) =>
			{
				isActive = hasteArtifact.isActive;
				hasteSpeed = hasteArtifact.speed;
				bool chanceActive = chanceByHpLoseComponent.isActivate;
				bool isReloadNeeded = false;
				if (isActive)
				{
					bool isEnd = cooldownComponent.canUse;
					if (isEnd)
					{
						hasteSpeed = -hasteSpeed;
						isActive = false;
						isSpeedChange = true;
					}
				}
				else if(chanceActive)
				{
					isActive = true;
					isReloadNeeded = true;
					isSpeedChange = true;
				}

				cooldownComponent.isReloadNeeded = isReloadNeeded;
				hasteArtifact.isActive = isActive;
			});

			if (!isSpeedChange) return;

			Entities.ForEach((Entity e,
				ref CameraComponent cameraComponent,
				ref MovingComponent movingComponent) =>
			{
				float speed = movingComponent.speed;
				speed += hasteSpeed;
				movingComponent.speed = speed;
			});
			Entities.ForEach((Entity e,
				ref PlayerTag playerTag,
				ref MovingComponent movingComponent) =>
			{
				float speed = movingComponent.speed;
				speed += hasteSpeed;
				movingComponent.speed = speed;
			});
		}
	}
}