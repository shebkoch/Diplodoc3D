using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts
{
	public class FrontTeleportArtifactProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public float distance;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new FrontTeleportArtifact
			{
				distance = distance,
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}