using System;
using Unity.Entities;
using Unity.Mathematics;

namespace Structures
{
	[Serializable]
	public struct RangedWeapon
	{
		public Entity bulletPrefab;
		public float lastAttack;
		public float cooldown;
		public float bulletSpeed;
		public int damage;
		public int bulletCount;
		public PreAttack preAttack;
		public float3 relativeAttackPosition;
	}
}