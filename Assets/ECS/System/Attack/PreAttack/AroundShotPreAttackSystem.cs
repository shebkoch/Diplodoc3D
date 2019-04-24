using ECS.Component.Attack;
using ECS.Component.Creatures;
using ECS.Component.Flags;
using Structures;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ECS.System.Attack.PreAttack
{
[DisableAutoCreation]	public class AroundShotPreAttackSystem : ComponentSystem
	{
		protected struct Player
		{
			public PlayerTag playerTag;
			public Transform transform;
		}
		protected struct PreAttack
		{
			public PreAttackComponent preAttackComponent;
		}

		protected override void OnUpdate()
		{
			float3 position = new float3();
			Entities.ForEach((Entity e,
				ref PlayerTag playerTag,
				ref Translation translation) =>
			{
				position = translation.Value;
			});
			Entities.ForEach((Entity e,
				ref PreAttackComponent preAttackComponent) =>
			{
				bool isAttacked = preAttackComponent.isAttacked;
				
				if(!isAttacked) return;

				RangedWeapon weapon = preAttackComponent.weapon;
				
				if(weapon.preAttack != Structures.PreAttack.AroundShot) return;
				
				for (int i = -1; i <= 1; i++)
				{
					for (int j = -1; j <= 1; j++)
					{
						if(i == 0 && j == 0) continue;
						GameObject bulletInstance = GameObject.Instantiate(weapon.bulletPrefab, position, quaternion.identity);
						MovingComponent movingComponent = bulletInstance.GetComponent<MovingComponent>();
						movingComponent.vertical = i;
						movingComponent.horizontal = j;
					}
				}

				preAttackComponent.isAttacked = false;
			});

		}
	}
}