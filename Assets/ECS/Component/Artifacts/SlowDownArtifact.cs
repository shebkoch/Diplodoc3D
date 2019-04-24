using Unity.Entities;
using Unity.Mathematics;

namespace ECS.Component.Artifacts
{
	public struct SlowDownArtifact : IComponentData
	{
		public float slow;
	}
}