using Structures;
using Unity.Entities;

namespace ECS.Component.Attack
{
	public struct RangedWeaponComponent : IComponentData
	{
		public bool isEnable;
		public RangedWeapon rangedWeapon;
	}
}