using Unity.Entities;

namespace ECS.Component.Creatures
{
	public struct ParametersComponent : IComponentData
	{
		public int health;
		public int maxHealth;
	}
}