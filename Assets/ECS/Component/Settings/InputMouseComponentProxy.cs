using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Settings
{
	public class InputMouseComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public float holdTime;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new InputMouseComponent
			{
				holdTime = holdTime,
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}