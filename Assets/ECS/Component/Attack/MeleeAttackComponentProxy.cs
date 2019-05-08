using Unity.Entities;
using Unity.Physics;
using Unity.Physics.Authoring;
using UnityEngine;
using Collider = Unity.Physics.Collider;
namespace ECS.Component.Attack
{
	
	public class MeleeAttackComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public GameObject colliderObj; 
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			Entity colliderEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(colliderObj, World.Active);
//			BlobAssetReference<Collider> collider = dstManager.GetComponentData<PhysicsCollider>(colliderEntity).Value;
			var data = new MeleeAttackComponent
			{
//				meleeCollider = collider
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}