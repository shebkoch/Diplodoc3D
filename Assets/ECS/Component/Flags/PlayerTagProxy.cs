using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Flags
{
	public class PlayerTagProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new PlayerTag
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}