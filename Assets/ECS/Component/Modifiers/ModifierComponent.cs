using Unity.Entities;

namespace ECS.Component.Modifiers
{
	public struct ModifierComponent : IComponentData
	{
		public ModifierState modifierState;
		public bool needActive;
	}
}