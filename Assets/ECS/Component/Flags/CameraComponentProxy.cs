using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Flags
{
	public class CameraComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new CameraComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}