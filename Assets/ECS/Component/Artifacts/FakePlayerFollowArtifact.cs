using Unity.Entities;
using Unity.Mathematics;
using Unity.Entities;

namespace ECS.Component.Artifacts
{
	public struct FakePlayerFollowArtifact : IComponentData
	{
		public float2 min;
		public float2 max;
	}
}