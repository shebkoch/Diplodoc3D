using ECS.Component.Damage;
using ECS.Component.Flags;
using Unity.Entities;
using Unity.Transforms;

namespace ECS.System
{
	public class DeathSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			int enemyDeathCount = 0;
			Entities.ForEach((Entity e,
				ref DeathComponent deathComponent) =>
			{				
				if (deathComponent.isDeathNeed)
				{
					if (EntityManager.HasComponent(e, typeof(EnemyTag)))
						enemyDeathCount++;
					
					PostUpdateCommands.DestroyEntity(e);

					if (EntityManager.HasComponent<Child>(e))
					{
						var buffer = EntityManager.GetBuffer<Child>(e);
						for (var i = 0; i < buffer.Length; i++)
						{
							PostUpdateCommands.DestroyEntity(buffer[i].Value);
						}
					}
				}
			});
			DeathCountComponent deathCountComponent = GetSingleton<DeathCountComponent>();
			deathCountComponent.count += enemyDeathCount;
			SetSingleton(deathCountComponent);
		}
	}
}