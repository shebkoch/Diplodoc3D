using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Flags
{
	public class PlayerTagProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public static Entity playerEntity;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			playerEntity = entity;
			var data = new PlayerTag
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}