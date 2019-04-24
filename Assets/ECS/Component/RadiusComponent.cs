using Unity.Entities;
using Unity.Mathematics;

namespace ECS.Component
{
	public struct RadiusComponent : IComponentData
	{
		public float3 startPos;
		public float radius;
		public float spread;
	}
}