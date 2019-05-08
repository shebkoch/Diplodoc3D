using System.Collections.Generic;
using ECS.Component;
using ECS.Component.Creatures;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ECS.System
{
	//TODO : to job
	public class SpawnSystem : ComponentSystem
	{

		protected override void OnUpdate()
		{
			List<SpawnHelper> list = new List<SpawnHelper>();
			Entities.ForEach((Entity e,
				SpawnComponent spawnComponent) =>
			{
				list = spawnComponent.list;
				spawnComponent.list = new List<SpawnHelper>();
				PostUpdateCommands.SetSharedComponent(e, spawnComponent);
			});
			var entityManager = World.Active.EntityManager;
			foreach (var spawnHelper in list)
			{
				for (int i = 0; i < spawnHelper.spawnPair.count; i++)
				{
					Entity instance = entityManager.Instantiate(spawnHelper.spawnPair.prefab);
					float3 position = spawnHelper.position;
					if (spawnHelper.needSpread)
					{
						position = Rand.OnCircle3D(0, spawnHelper.radius, -spawnHelper.spread, spawnHelper.spread) + position;
					}
					entityManager.SetComponentData(instance, new Translation {Value = position});
					if (spawnHelper.needMovingComponent)
					{
						entityManager.SetComponentData(instance, new MovingComponent
						{
							speed = spawnHelper.speed,
							vertical = spawnHelper.direction.y,
							horizontal = spawnHelper.direction.x
						});						

					}
				}
			}
		}
	}
}