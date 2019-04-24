using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts
{
	public class RegenByShotArtifactProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public int shotCount;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new RegenByShotArtifact
			{
				shotCount = shotCount,
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}