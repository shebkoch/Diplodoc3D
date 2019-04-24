using ECS.Component;
using ECS.Component.Creatures;
using ECS.Component.Damage;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
[DisableAutoCreation]	public class EnemyDamageSystem : ComponentSystem
	{
		protected struct Enemy
		{
			public DamageComponent damageComponent;
			public ParametersComponent parametersComponent;
		}

		protected override void OnUpdate()
		{
			Entities.ForEach((Entity e,
				ref DamageComponent damageComponent,
				ref ParametersComponent parametersComponent) =>
			{
				bool isDamageDeal = damageComponent.isDamageDeal;
				if (!isDamageDeal) return;

				int health = parametersComponent.health;
					
				health--;
					
				parametersComponent.health = health;
				damageComponent.isDamageDeal = false;
			});
		}


	}
}