using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine;
using Collider = Unity.Physics.Collider;
namespace ECS.Component.Attack
{
	
	public class MeleeAttackComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public GameObject colliderObj;
		public float3 colliderRelativePosition;
		public bool isAttackNeed;
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			Entity colliderEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(colliderObj, World.Active);
			BlobAssetReference<Collider> meleeCollider = dstManager.GetComponentData<PhysicsCollider>(colliderEntity).Value;
			var data = new MeleeAttackComponent
			{
				meleeCollider = meleeCollider,
				colliderRelativePosition = colliderRelativePosition,
				isAttackNeed = isAttackNeed
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}