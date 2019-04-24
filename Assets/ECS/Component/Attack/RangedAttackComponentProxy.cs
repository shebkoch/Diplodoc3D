using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Attack
{
	public class RangedAttackComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new RangedAttackComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}