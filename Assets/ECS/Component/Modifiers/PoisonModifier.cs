using Unity.Mathematics;
using UnityEngine;using Unity.Entities;

namespace ECS.Component.Modifiers
{
	public struct PoisonModifier : IComponentData
	{
		public int damage;
	}
}