using Unity.Entities;

namespace ECS.Component.Artifacts
{
	public struct HpRegenArtifact : IComponentData
	{
		public bool isEnable;
	}
}