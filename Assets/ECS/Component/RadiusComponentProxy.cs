using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component
{
	public class RadiusComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public float3 startPos;
		public float radius;
		public float spread;
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new RadiusComponent
			{
				startPos = startPos,
				radius = radius,
				spread = spread 
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}