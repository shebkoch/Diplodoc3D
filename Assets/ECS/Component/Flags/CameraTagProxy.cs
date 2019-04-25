using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace ECS.Component.Flags
{
	public class CameraTagProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public Entity cameraEntity;
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			cameraEntity = entity;
			var data = new CameraTag
			{
			};
			dstManager.AddComponentData(entity, data);
		}

		private void LateUpdate()
		{
			Translation translation = World.Active.EntityManager.GetComponentData<Translation>(cameraEntity);
			transform.position = translation.Value;
		}
	}
}