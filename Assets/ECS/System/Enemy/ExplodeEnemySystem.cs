using ECS.Component;
using ECS.Component.Creatures;
using ECS.Component.Damage;
using ECS.Component.Enemy;
using ECS.Component.Flags;
using ECS.Component.Relations;
using ECS.System.Relations;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Enemy
{
	[UpdateAfter(typeof(PlayerFollowSystem))]
	public class ExplodeEnemySystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			int damage = 0;
			Entities.ForEach((Entity e,
				ref EnemyTag enemyTag,
				ref ExplodeEnemyComponent explodeEnemyComponent,
				ref PlayerFollowComponent playerFollowComponent,
				ref ParametersComponent parametersComponent) =>
			{
				float explodeDistance = explodeEnemyComponent.distance;
				float distanceToPlayer = playerFollowComponent.distanceToPlayer;
				int explodeDamage = explodeEnemyComponent.damage;

				if (math.abs(distanceToPlayer) < math.abs(explodeDistance))
				{
					damage += explodeDamage;
					parametersComponent.health -= 100;
				}
			});
			Entities.ForEach((Entity e,
				ref PlayerTag playerTag,
				ref DamageReceivedComponent damageReceivedComponent) =>
			{
				damageReceivedComponent.damage += damage;
			});
		}
	}
}