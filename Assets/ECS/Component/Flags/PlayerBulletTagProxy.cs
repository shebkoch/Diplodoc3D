using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Flags
{
	public class PlayerBulletTagProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new PlayerBulletTag
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}