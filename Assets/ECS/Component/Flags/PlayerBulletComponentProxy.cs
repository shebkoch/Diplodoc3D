using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Flags
{
	public class PlayerBulletComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new PlayerBulletComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}