using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Creatures
{
	public struct AnimatorComponent : IComponentData
	{
		public Animator animator;
		public string attackAnimation;
		public bool isAnimationNeeded;
	}
	
}