using System.Collections.Generic;
using ECS.Component;
using Unity.Entities;

public static class SpawnAdder
{
	public static void Add(List<SpawnHelper> spawnHelpers, EntityManager entityManager, EntityQueryBuilder entities)
	{
		Entity entity = Entity.Null;
		SpawnComponent entitySpawnComponent = new SpawnComponent();
			
		entities.ForEach((Entity e,
			SpawnComponent spawnComponent) =>
		{
			entity = e;
			entitySpawnComponent = spawnComponent;
		});
		if (entity != Entity.Null)
		{
			if(entitySpawnComponent.list == null) entitySpawnComponent.list = new List<SpawnHelper>();
			entitySpawnComponent.list.AddRange(spawnHelpers);
			entityManager.SetSharedComponentData(entity, entitySpawnComponent);
		}
	}
}