using Unity.Mathematics;
using UnityEngine;using Unity.Entities;

namespace ECS.Component.Modifiers
{
	public struct StunModifier : IComponentData
	{
		public float keepSpeed;
	}
}