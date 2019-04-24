using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts
{
	public class StoneGazeArtifactProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public float duration;
		public float radius;
		

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new StoneGazeArtifact
			{
				duration = duration,
				radius = radius,

			};
			dstManager.AddComponentData(entity, data);
		}
	}
}