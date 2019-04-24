using UnityEngine;using Unity.Entities;

namespace ECS.Component.Attack
{
	public struct MeleeAttackComponent : IComponentData
	{
		public bool isAttackNeed;
		public Collider2D weaponCollider;
	}
}