using Structures;
using UnityEngine;using Unity.Entities;

namespace ECS.Component.Items
{
	public struct PickUpMeleeComponent : IComponentData
	{
		public bool isUsed;
		public MeleeWeapon weapon;
		public GameObject weaponObject;
	}
}