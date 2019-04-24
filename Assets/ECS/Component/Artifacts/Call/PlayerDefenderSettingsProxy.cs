using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts.Call
{
	public class PlayerDefenderSettingsProxy : MonoBehaviour, IConvertGameObjectToEntity
	{

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new PlayerDefenderSettings
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}