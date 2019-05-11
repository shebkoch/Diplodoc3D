using Unity.Entities;
using Unity.Mathematics;

namespace ECS.Component
{
	public struct DebugComponent : IComponentData
	{
		public int value;
	}
}