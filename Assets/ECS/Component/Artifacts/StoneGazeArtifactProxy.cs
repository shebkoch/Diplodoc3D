using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts
{
	public class StoneGazeArtifactProxy : MonoBehaviour, IConvertGameObjectToEntity
	{

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new StoneGazeArtifact
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}