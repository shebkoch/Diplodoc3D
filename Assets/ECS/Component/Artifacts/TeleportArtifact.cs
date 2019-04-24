using Unity.Mathematics;
using Unity.Entities;

namespace ECS.Component.Artifacts
{
	public struct TeleportArtifact : IComponentData
	{
		public bool active;
		public float3 location;
	}
}