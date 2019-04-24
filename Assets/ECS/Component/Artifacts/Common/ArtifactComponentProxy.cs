using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts.Common
{
	public class ArtifactComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new ArtifactComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}