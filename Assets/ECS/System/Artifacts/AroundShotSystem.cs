using System;
using System.Collections.Generic;
using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Artifacts.Util;
using ECS.Component.Flags;
using ECS.Component.Stats;
using ECS.System.Artifacts.Util;
using ECS.System.Stats;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace ECS.System.Artifacts
{
	
	[UpdateAfter(typeof(ChanceByHpLoseSystem))]
[DisableAutoCreation]	public class AroundShotSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			Random random = Rand.GetRandom();
			float3 playerPos = new float3();
			Entities.ForEach((Entity e,
				ref PlayerTag playerTag,
				ref Translation translation) =>
			{
				playerPos = translation.Value;
			});
			List<SpawnHelper> spawnHelpers = new List<SpawnHelper>();
			Entities.ForEach((Entity e,
				AroundShotPassiveArtifact aroundShotPassiveArtifact,
				ref ChanceByHpLoseComponent chanceByHpLoseComponent) =>
			{
				bool isActivate = chanceByHpLoseComponent.isActivate;
				Entity bullet = aroundShotPassiveArtifact.bullet;
				float speed = aroundShotPassiveArtifact.speed;
				if (isActivate)
				{
					//TODO: fix anysizing
					for (int i = -1; i <= 1; i++)
					{
						for (int j = -1; j <= 1; j++)
						{
							if(i == 0 && j == 0) continue;
							
							spawnHelpers.Add(new SpawnHelper
							{
								spawnPair = new SpawnPair{prefab = bullet, count = 1},
								position = playerPos,
								direction = new float2(i,j),
								speed = speed
							});
						}
					}
				}
			});
			
			Entities.ForEach((Entity e,
				SpawnComponent spawnComponent) =>
			{
				spawnComponent.list.AddRange(spawnHelpers);
				PostUpdateCommands.SetSharedComponent(e, spawnComponent);
			});

		}
	}
}