using Unity.Entities;

namespace ECS.Component
{
	public struct DamageReceivedComponent : IComponentData
	{
		public int damage;
	}
}