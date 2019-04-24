using Unity.Entities;

namespace ECS.Component.Artifacts.Common
{
	public struct ArtifactUsingComponent : IComponentData
	{
		public bool isCastNeeded;
		public bool canUse;
	}
}