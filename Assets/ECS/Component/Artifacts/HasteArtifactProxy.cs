using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts
{
	public class HasteArtifactProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public float speed;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new HasteArtifact
			{
				speed = speed,
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}