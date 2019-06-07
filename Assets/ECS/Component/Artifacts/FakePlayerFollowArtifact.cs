using Unity.Entities;
using Unity.Mathematics;

namespace ECS.Component.Artifacts
{
	public struct FakePlayerFollowArtifact : IComponentData
	{
		public float2 min;
		public float2 max;
	}
}