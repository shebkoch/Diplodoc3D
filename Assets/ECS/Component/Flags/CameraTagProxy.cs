using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Flags
{
	public class CameraTagProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new CameraTag
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}