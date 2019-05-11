using Unity.Entities;
using UnityEngine;

namespace ECS.Component
{
	public class DebugComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public int value;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new DebugComponent
			{
				value = value,
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}