using Unity.Entities;

namespace ECS.Component.Artifacts
{
	public struct CooldownReduceArtifact : IComponentData
	{
		public float percent;
	}
}