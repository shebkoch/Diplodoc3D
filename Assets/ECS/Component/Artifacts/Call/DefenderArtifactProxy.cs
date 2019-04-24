using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts.Call
{
	public class DefenderArtifactProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new DefenderArtifact
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}