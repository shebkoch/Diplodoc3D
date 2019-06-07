using System;
using Unity.Entities;
using Unity.Mathematics;

namespace ECS.Component
{
	[Serializable]
	public struct PrefabComponent : IComponentData
	{
		public float3 position;
		public float2 positionSpread;
		
		public bool needSpread;
		public float3 radius;
		public float spread;
		
		public bool needMovingComponent;
		public float2 direction;
		public float speed;
		
	}
}