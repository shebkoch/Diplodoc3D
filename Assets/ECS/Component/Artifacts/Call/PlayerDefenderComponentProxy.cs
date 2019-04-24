using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts.Call
{
	public class PlayerDefenderComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new PlayerDefenderComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}