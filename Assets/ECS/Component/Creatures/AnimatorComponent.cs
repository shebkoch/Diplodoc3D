using Unity.Entities;

namespace ECS.Component.Creatures
{
	public struct AnimatorComponent : IComponentData
	{
		//public Animator animator;
		//public string attackAnimation;
		public bool isAttackNeeded;
		public bool run;
		public bool isDeathNeeded;
	}
}