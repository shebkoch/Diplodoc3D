using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Stats
{
	public class PlayerParametersStatComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new PlayerParametersStatComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}