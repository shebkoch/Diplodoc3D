using Unity.Entities;

namespace ECS.Component.Flags
{
	public struct EnemyTag : IComponentData
	{
		public bool isEnable;
	}
}