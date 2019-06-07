using Unity.Entities;

namespace ECS
{
	public struct DeathCountComponent : IComponentData
	{
		public int count;
	}
}