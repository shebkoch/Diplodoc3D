using Unity.Entities;

namespace ECS.Component.Damage
{
	public struct DeathComponent : IComponentData
	{
		public bool isDeathNeed;
		public bool isDie;
	}
}