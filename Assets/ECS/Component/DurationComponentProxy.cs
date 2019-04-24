using Unity.Entities;
using UnityEngine;

namespace ECS.Component
{
	public class DurationComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public float duration;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new DurationComponent
			{
				duration = duration,
				last = float.MinValue
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}