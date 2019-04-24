using ECS.Component.Creatures;
using ECS.Component.Modifiers;
using Unity.Entities;

namespace ECS.System.Modifiers
{
	[UpdateAfter(typeof(ModifierSystem))]
[DisableAutoCreation]	public class StunModifierSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			ModifierState modifierState = ModifierState.Inactive;
			Entities.ForEach((Entity e,
				ref ModifierComponent modifierComponent) =>
			{
				modifierState = modifierComponent.modifierState;
			});
			Entities.ForEach((Entity e,
				ref StunModifier stunModifier,
				ref MovingComponent movingComponent) =>
			{
				float speed = movingComponent.speed;

				switch (modifierState)
				{
					case ModifierState.Before:
						stunModifier.keepSpeed = speed;
						break;
					case ModifierState.Active:
						movingComponent.speed = 0;
						break;
					case ModifierState.After:
						movingComponent.speed = stunModifier.keepSpeed;
						break;
				}
			});
		}
	}
}