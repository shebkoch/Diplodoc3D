using Structures;
using Unity.Entities;

namespace ECS.Component.Attack
{
	public struct MeleeWeaponComponent : IComponentData
	{
		public MeleeWeapon meleeWeapon;
	}
}