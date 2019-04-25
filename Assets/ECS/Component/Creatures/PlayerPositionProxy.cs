using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Creatures
{
	public class PlayerPositionProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new PlayerPosition
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}