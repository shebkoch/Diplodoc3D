using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component.Artifacts
{
	public class AroundShotPassiveArtifactProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public GameObject bullet;
		public float speed;
		public float3 relativePosition;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			Entity prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(bullet, World.Active);
			var data = new AroundShotPassiveArtifact
			{
				bullet = prefab,
				speed = speed,
				relativePosition = relativePosition

			};
			dstManager.AddComponentData(entity, data);
		}
	}
}