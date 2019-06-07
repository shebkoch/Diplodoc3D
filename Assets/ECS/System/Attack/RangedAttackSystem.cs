using System.Collections.Generic;
using ECS.Component;
using ECS.Component.Attack;
using Structures;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ECS.System.Attack
{
	public class RangedAttackSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			List<SpawnHelper> bulletSpawnList = new List<SpawnHelper>();
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

				//float angle = math.degrees(math.atan2(direction.y, direction.x));
				//float3 forward = new float3(0.0f, 0.0f, 1f);

				float2 bulletDirection = math.normalize(attackPos.xy);
				//ECS

				SpawnHelper bulletSpawnHelper = new SpawnHelper
				{
					spawnPair = new EntitySpawnPair {prefab = weapon.bulletPrefab, count = 1},
					prefabComponent = new PrefabComponent
					{
						position = position + weapon.relativeAttackPosition,
						needMovingComponent = true,
						direction = bulletDirection,
						speed = weapon.bulletSpeed
					}
				};
				bulletSpawnList.Add(bulletSpawnHelper);
				preAttackComponent.weapon = weapon;
				preAttackComponent.isAttacked = true;
				//ECS
//				if (!isWeaponEnable)
//				{
//					SpriteRenderer spriteRenderer = bullet.GetComponent<SpriteRenderer>();
//					spriteRenderer.sprite = weapon.sprite;
//					spriteRenderer.color = Color.white;
//					bullet.transform.localScale = float3.zero + 1;
//				}
				rangedWeaponComponent.rangedWeapon = weapon;
				rangedWeaponComponent.isEnable = isWeaponEnable;
			});

			SpawnAdder.Add(bulletSpawnList, EntityManager, Entities);
		}
	}
}