using System.Collections.Generic;
using ECS.Component;
using ECS.Component.Enemy;
using ECS.Component.Flags;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
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
				List<HybridSpawnPair> enemies = enemyGeneratorComponent.enemies;
				
				int wave = enemyGeneratorComponent.wave;
				int breakAfter = enemyGeneratorComponent.breakAfter;
				int spread = enemyGeneratorComponent.countSpread;
				int wavePlus = enemyGeneratorComponent.wavePlus;
				float radius = radiusComponent.radius;
				if (wave % breakAfter != 0)
				{
					for (var i = 0; i < enemies.Count; i++)
					{
						var hybridSpawnPair = enemies[i];
						float relativeSpread = (float) spread / hybridSpawnPair.count;
						int plus = wavePlus * wave;
						if (i == 0) plus /= 10;
						int count = hybridSpawnPair.count + plus;
						count += (int) Random.Range(-count * relativeSpread, count * relativeSpread);
						hybridSpawnPair.count = count;
						
						spawnHelpers.Add(new SpawnHelper()
						{
							hybrid = true,
							hybridSpawnPair = hybridSpawnPair,
							prefabComponent = new PrefabComponent
							{
								position = playerPos,
								needSpread = true,
								positionSpread = enemyGeneratorComponent.positionSpread,
								spread = enemyGeneratorComponent.countSpread,
								radius = radius
							}
						});
					}
				}

				enemyGeneratorComponent.wave = wave + 1;
				PostUpdateCommands.SetSharedComponent(e, enemyGeneratorComponent);
				cooldownComponent.isReloadNeeded = true;
			});

			SpawnAdder.Add(spawnHelpers, EntityManager, Entities);
		}
	}
}