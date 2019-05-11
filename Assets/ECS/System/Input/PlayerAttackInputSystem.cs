using ECS.Component.Attack;
using ECS.Component.Flags;
using ECS.Component.Settings;
using Unity.Entities;

namespace ECS.System.Input
{
	public class PlayerAttackInputSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			bool rangedPress = false;
			bool meleePress = false;
			Entities.ForEach((Entity e,
				ref InputAttackComponent inputAttackComponent) =>
			{
				meleePress = inputAttackComponent.meleePress;
				rangedPress = inputAttackComponent.rangedPress;
			});
			Entities.ForEach((Entity e,
				ref PlayerTag playerTag,
				ref RangedAttackComponent rangedAttackComponent) =>
			{
				rangedAttackComponent.isAttackNeed = rangedPress;
			});
			Entities.ForEach((Entity e,
				ref PlayerTag playerTag,
				ref MeleeAttackComponent meleeAttackComponent) =>
			{
				meleeAttackComponent.isAttackNeed = meleePress;
			});

		}
	}
}