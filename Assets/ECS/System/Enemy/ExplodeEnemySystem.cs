using ECS.Component.Creatures;
using ECS.Component.Damage;
using ECS.Component.Enemy;
using ECS.Component.Flags;
using ECS.Component.Relations;
using ECS.System.Relations;
using Unity.Entities;
using Unity.Mathematics;

namespace ECS.System.Enemy
{
	[UpdateAfter(typeof(PlayerFollowSystem))]
[DisableAutoCreation]	public class ExplodeEnemySystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			int damage = 0;
			Entities.ForEach((Entity e,
				ref EnemyTag enemyTag,
				ref ExplodeEnemyComponent explodeEnemyComponent,
				ref PlayerFollowComponent playerFollowComponent,
				ref DeathComponent deathComponent ) =>
			{
				float explodeDistance = explodeEnemyComponent.distance;
				float distanceToPlayer = playerFollowComponent.distanceToPlayer;
				int explodeDamage = explodeEnemyComponent.damage;

				if (math.abs(distanceToPlayer) < math.abs(explodeDistance))
				{
					damage += explodeDamage;
					deathComponent.isDeathNeed = true;
				}
			});
			Entities.ForEach((Entity e,
				ref PlayerTag playerTag,
				ref ParametersComponent parametersComponent) =>
			{
				parametersComponent.health -= damage;
			});
		}
	}
}