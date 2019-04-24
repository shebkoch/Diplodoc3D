using ECS.Component.Attack;
using ECS.Component.Creatures;
using Structures;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ECS.System.Attack
{
[DisableAutoCreation]	public class RangedAttackSystem : ComponentSystem
	{
		protected struct Creature
		{
			
		}

		protected override void OnUpdate()
		{
			Entities.ForEach((Entity e,
				ref Translation translation,
				ref RangedWeaponComponent rangedWeaponComponent,
				ref RangedAttackComponent rangedAttackComponent,
				ref PreAttackComponent preAttackComponent) =>
			{
				float3 attackPos = rangedAttackComponent.endPoint;
				RangedWeapon weapon = rangedWeaponComponent.rangedWeapon;
				float3 position = translation.Value;
				bool isAttackNeed = rangedAttackComponent.isAttackNeed;
				bool isWeaponEnable = rangedWeaponComponent.isEnable;
				float currentTime = Time.realtimeSinceStartup;
				
				if (!isAttackNeed || !isWeaponEnable || weapon.lastAttack + weapon.cooldown > currentTime) return;

				weapon.lastAttack = currentTime;
				weapon.bulletCount--;
				if (weapon.bulletCount == 0) isWeaponEnable = false;
				float3 direction = attackPos - position;
				float angle = math.degrees(math.atan2(direction.y, direction.x));
				float3 forward = new float3(0.0f, 0.0f, 1f);
				
				//ECS
				GameObject bullet = GameObject.Instantiate(weapon.bulletPrefab, position, quaternion.identity);
				bullet.transform.rotation = Quaternion.AngleAxis(angle, forward);
				
				float2 result = math.normalize(direction.xy);
				float horizontal = result.x;
				float vertical = result.y;

				preAttackComponent.weapon = weapon;
				preAttackComponent.isAttacked = true;
				//ECS
				if (!isWeaponEnable)
				{
					SpriteRenderer spriteRenderer = bullet.GetComponent<SpriteRenderer>();
					spriteRenderer.sprite = weapon.sprite;
					spriteRenderer.color = Color.white;
					bullet.transform.localScale = float3.zero + 1;
				}
				var bulletMoving = bullet.GetComponent<MovingComponent>();
				bulletMoving.vertical = vertical;
				bulletMoving.horizontal = horizontal;
				bulletMoving.speed = weapon.bulletSpeed;
//				var bulletCollision = bullet.GetComponent<CollisionComponent>();
//				bulletCollision.damage = weapon.damage;
				
				rangedWeaponComponent.rangedWeapon = weapon;
				rangedWeaponComponent.isEnable = isWeaponEnable;
			
			});
		}
	}
}