using Unity.Entities;
using Unity.Mathematics;

namespace ECS.Component.Artifacts
{
	public struct LuckArtifact : IComponentData
	{
		public int chance;
	}
}