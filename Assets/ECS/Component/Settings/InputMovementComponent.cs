using Unity.Entities;

namespace ECS.Component.Settings
{
	public struct InputMovementComponent : IComponentData
	{
		public float horizontal;
		public float vertical;
	}
}