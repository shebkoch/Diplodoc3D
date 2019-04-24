using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts
{
	public class LuckArtifactProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public int chance;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new LuckArtifact
			{
				chance = chance,
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}