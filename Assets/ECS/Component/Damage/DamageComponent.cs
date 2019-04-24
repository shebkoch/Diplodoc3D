using Unity.Entities;

namespace ECS.Component.Damage
{
	public struct DamageComponent : IComponentData
	{
		public bool isDamageDeal;
	}
}