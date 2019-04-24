using Unity.Entities;
using Unity.Mathematics;

namespace ECS.Component.Artifacts
{
	public struct RegenByShotArtifact : IComponentData
	{
		public int shotCount;
	}
}