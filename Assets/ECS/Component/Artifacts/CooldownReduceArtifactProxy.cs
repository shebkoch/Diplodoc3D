using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts
{
	public class CooldownReduceArtifactProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public float percent;
		

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new CooldownReduceArtifact
			{
				percent = percent,
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}