using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace ECS.Component.Modifiers
{
	public struct ModifierComponent : IComponentData
	{
		public ModifierState modifierState;
		public bool needActive;
	}
}