using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Damage
{
	public class DamageComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new DamageComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}