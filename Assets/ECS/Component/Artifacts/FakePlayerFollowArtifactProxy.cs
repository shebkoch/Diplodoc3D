using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component.Artifacts
{
	public class FakePlayerFollowArtifactProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public float2 min;
		public float2 max;
		

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new FakePlayerFollowArtifact
			{
				min = min,
				max = max,

			};
			dstManager.AddComponentData(entity, data);
		}
	}
}