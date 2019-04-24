using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts.Util
{
	public class ChanceArtifactComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public int chance;
		

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new ChanceArtifactComponent
			{
				chance = chance,
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}