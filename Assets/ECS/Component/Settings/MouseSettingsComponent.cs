using Unity.Entities;

namespace ECS.Component.Settings
{
	public struct MouseSettingsComponent : IComponentData
	{
		public float holdCooldown;
	}
}