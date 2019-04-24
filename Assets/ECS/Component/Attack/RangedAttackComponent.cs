using Unity.Mathematics;
using Unity.Entities;

namespace ECS.Component.Attack
{
	public struct RangedAttackComponent : IComponentData
	{
		public float3 endPoint;
		public bool isAttackNeed;
	}
}