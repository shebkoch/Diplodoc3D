using System;
using Unity.Mathematics;

namespace ECS.Component
{
	[Serializable]
	public struct SpawnHelper
	{
		public SpawnPair spawnPair;
		public float3 position;

		public bool needSpread;
		public float3 radius;
		public float spread;
		
		public bool needMovingComponent;
		public float2 direction;
		public float speed;
	}
}