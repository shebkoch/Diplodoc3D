using UnityEngine;using Unity.Entities;
using Unity.Mathematics;
using Collider = Unity.Physics.Collider;

namespace ECS.Component.Attack
{
	public struct MeleeAttackComponent : IComponentData
	{
		public bool isAttackNeed;
		public BlobAssetReference<Collider> meleeCollider;
		public float3 colliderRelativePosition;
	}
}