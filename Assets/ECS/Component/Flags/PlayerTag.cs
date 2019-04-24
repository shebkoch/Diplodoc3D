using Unity.Entities;

namespace ECS.Component.Flags
{
	public struct PlayerTag : IComponentData
	{
		public bool isEnable;
	}
}