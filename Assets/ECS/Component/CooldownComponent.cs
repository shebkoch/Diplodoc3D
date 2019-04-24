using Unity.Entities;

namespace ECS.Component
{
	public struct CooldownComponent : IComponentData
	{
		public bool canUse;
		public float cooldown;
		public float last;
		public bool isReloadNeeded;
	}
}