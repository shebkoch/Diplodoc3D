using Unity.Entities;
using Unity.Mathematics;

namespace ECS.Component.Relations
{
	public struct CreatureTransformComponent : IComponentData
	{
		public float3 lastFramePosition;
	}
}