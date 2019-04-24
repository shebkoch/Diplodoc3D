using Unity.Entities;
using Unity.Mathematics;
using Unity.Entities;

namespace ECS.Component.Artifacts
{
	public struct HasteArtifact : IComponentData
	{
		public float speed;
		public bool isActive;
	}
}