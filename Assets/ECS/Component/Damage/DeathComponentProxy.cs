using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Damage
{
	public class DeathComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new DeathComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}