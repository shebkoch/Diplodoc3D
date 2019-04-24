using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts.Common
{
	public class ArtifactUsingComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public bool canUse;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new ArtifactUsingComponent
			{
				canUse = canUse,
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}