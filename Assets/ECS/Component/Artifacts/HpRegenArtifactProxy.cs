using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts
{
	public class HpRegenArtifactProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new HpRegenArtifact
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}