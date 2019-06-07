using Unity.Entities;

namespace ECS.Component.Artifacts
{
	public struct LuckArtifact : IComponentData
	{
		public int chance;
	}
}