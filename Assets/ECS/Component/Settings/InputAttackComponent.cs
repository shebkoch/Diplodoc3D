using Unity.Entities;

namespace ECS.Component.Settings
{
	public struct InputAttackComponent : IComponentData
	{
		public bool meleePress;
		public bool rangedPress;
	}
}