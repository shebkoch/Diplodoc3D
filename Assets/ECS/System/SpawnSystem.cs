using System.Collections.Generic;
using ECS.Component;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace ECS.System
{
	//TODO : to job
	public class SpawnSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			List<SpawnHelper> list = new List<SpawnHelper>();
			Entity spawnEntity = Entity.Null;
			SpawnComponent _spawnComponent = new SpawnComponent();
			Entities.ForEach((Entity e,
				SpawnComponent spawnComponent) =>
			{
				list = spawnComponent.list;
				spawnComponent.list = new List<SpawnHelper>();
				spawnEntity = e;
			});
			EntityManager.SetSharedComponentData(spawnEntity, _spawnComponent);
			
			foreach (var spawnHelper in list)
			{
				if (spawnHelper.hybrid)
				{
					Entity entity = spawnHelper.hybridSpawnPair.entity;
					int length = spawnHelper.hybridSpawnPair.count;

					NativeList<Entity> entityList = Instantiate(spawnHelper.prefabComponent, entity, length);

					for (int i = 0; i < length; i++)
					{
						GameObject gameObject = GameObject.Instantiate(spawnHelper.hybridSpawnPair.gameObject);
						gameObject.GetComponent<CopyEntityTransform>().entity = entityList[i];
					}					
				}
				else
					Instantiate(spawnHelper.prefabComponent, spawnHelper.spawnPair.prefab, spawnHelper.spawnPair.count);
			}
		}

		private NativeList<Entity> Instantiate(PrefabComponent prefabComponent, Entity entity, int length)
		{
			NativeList<Entity> entityList = new NativeList<Entity>(Allocator.Temp);
			entityList.ResizeUninitialized(length);
			EntityManager.Instantiate(entity, entityList);
			
			for (var i = 0; i < entityList.Length; i++)
				PostUpdateCommands.AddComponent(entityList[i], prefabComponent);

			return entityList;
		}
	}
}