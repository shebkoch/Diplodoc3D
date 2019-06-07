using Unity.Entities;
using UnityEngine;

namespace ECS.Component
{
	public class DamageReceivedComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new DamageReceivedComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}