using Unity.Entities;

namespace ECS.Component.Artifacts
{
	public struct RegenByShotArtifact : IComponentData
	{
		public int shotCount;
	}
}