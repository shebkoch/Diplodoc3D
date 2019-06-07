using Unity.Entities;
using UnityEngine;

namespace ECS.Component
{
	public class PrefabComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public PrefabComponent prefabComponent;
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = prefabComponent;
			dstManager.AddComponentData(entity, data);
		}
	}
}