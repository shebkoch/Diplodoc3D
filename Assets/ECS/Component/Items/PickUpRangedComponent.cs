using Structures;
using Unity.Entities;

namespace ECS.Component.Items
{
	public struct PickUpRangedComponent : IComponentData

	{
		public bool isUsed;
		public RangedWeapon weapon;
	}
}