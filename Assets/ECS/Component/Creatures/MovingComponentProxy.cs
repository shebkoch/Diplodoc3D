using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Creatures
{
	public class MovingComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public float speed;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new MovingComponent
			{
				speed = speed,
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}