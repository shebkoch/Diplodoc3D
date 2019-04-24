using Unity.Entities;
using Unity.Mathematics;


namespace ECS.Component.Artifacts
{
	public struct PhaseArtifact : IComponentData
	{
		public bool isActive;
	}
}