using System.Collections.Generic;
using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Enemy;
using ECS.Component.Flags;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ECS.System.Enemy
{
	public class EnemyGeneratorSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			float3 playerPos = new float3();

			Entities.ForEach((Entity e,
				ref PlayerTag playerTag,
				ref Translation translation) =>
			{
				playerPos = translation.Value;
			});
			
			List<SpawnHelper> spawnHelpers = new List<SpawnHelper>();
			
			Entities.ForEach((Entity e,
				EnemyGeneratorComponent enemyGeneratorComponent,
				ref CooldownComponent cooldownComponent,
				ref RadiusComponent radiusComponent) =>
			{
				bool canUse = cooldownComponent.canUse;
				if (!canUse) return;
				List<SpawnPair> enemies = enemyGeneratorComponent.enemies;
				int wave = enemyGeneratorComponent.wave;
				int breakAfter = enemyGeneratorComponent.breakAfter;
				int spread = enemyGeneratorComponent.countSpread;
				int wavePlus = enemyGeneratorComponent.wavePlus;
				float radius = radiusComponent.radius;
				if (wave % breakAfter != 0)
				{
					for (var i = 0; i < enemies.Count; i++)
					{
						var spawnPair = enemies[i];
						float relativeSpread = (float) spread / spawnPair.count;
						int count = spawnPair.count + wave * wavePlus;
						count += (int) Random.Range(-count * relativeSpread, count * relativeSpread);

						spawnHelpers.Add(new SpawnHelper()
						{
							spawnPair = new SpawnPair()
							{
								count = count,
								prefab = spawnPair.prefab
							},
							position = playerPos,
							needSpread = true,
							spread = enemyGeneratorComponent.countSpread,
							radius = radius
						});
					}
				}
				enemyGeneratorComponent.wave = wave + 1;
				PostUpdateCommands.SetSharedComponent(e, enemyGeneratorComponent);
				cooldownComponent.isReloadNeeded = true;
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