using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Settings
{
	public class MouseSettingsComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new MouseSettingsComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}