using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Settings
{
	public class InputMovementComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new InputMovementComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}