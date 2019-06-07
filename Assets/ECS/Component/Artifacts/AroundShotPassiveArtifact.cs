using Unity.Entities;
using Unity.Mathematics;

namespace ECS.Component.Artifacts
{
	public struct AroundShotPassiveArtifact : IComponentData
	{
		public Entity bullet;
		public float speed;
		public float3 relativePosition;
		public int2 bulletCount;
	}
}