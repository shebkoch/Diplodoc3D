using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts.Call
{
	public class PlayerCallArtifactComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new PlayerCallArtifactComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}