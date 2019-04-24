using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Attack
{
	public class MeleeAttackComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public Collider weaponCollider;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new MeleeAttackComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}