using Unity.Mathematics;
using UnityEngine;using Unity.Entities;

namespace ECS.Component.Modifiers
{
	public struct SpeedChangeModifier : IComponentData
	{
		public float lastSpeed;
	}
}