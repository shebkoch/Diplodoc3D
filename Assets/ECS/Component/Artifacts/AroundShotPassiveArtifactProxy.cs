using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts
{
	public class AroundShotPassiveArtifactProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public GameObject bullet;
		public float speed;
		

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			
			var data = new AroundShotPassiveArtifact
			{
				bullet = conversionSystem.GetPrimaryEntity(bullet),
				speed = speed,

			};
			dstManager.AddSharedComponentData(entity, data);
		}
	}
}