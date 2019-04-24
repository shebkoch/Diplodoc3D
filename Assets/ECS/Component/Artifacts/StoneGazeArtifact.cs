using Unity.Entities;

namespace ECS.Component.Artifacts
{
	public struct StoneGazeArtifact : IComponentData
	{
		public float duration;
		public float radius;
	}
}