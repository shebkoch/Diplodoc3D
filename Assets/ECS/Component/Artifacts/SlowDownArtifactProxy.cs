using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts
{
	public class SlowDownArtifactProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public float slow;
		
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new SlowDownArtifact
			{
				slow = slow,
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}