using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Creatures
{
	public class RotationComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new RotationComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}