using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component.Artifacts
{
	public class TeleportArtifactProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public float3 location;
		
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new TeleportArtifact
			{
				location = location,

			};
			dstManager.AddComponentData(entity, data);
		}
	}
}