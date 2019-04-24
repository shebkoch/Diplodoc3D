using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts
{
	public class PhaseArtifactProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new PhaseArtifact
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}