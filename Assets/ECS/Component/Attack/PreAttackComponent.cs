using Structures;
using Unity.Entities;

namespace ECS.Component.Attack
{
	public struct PreAttackComponent : IComponentData
	{
		public bool isAttacked;
		public RangedWeapon weapon;
	}
}