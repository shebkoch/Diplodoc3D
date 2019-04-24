using System;
using ECS.Component;
using ECS.Component.Modifiers;
using Unity.Entities;

namespace ECS.System.Modifiers
{
[DisableAutoCreation]	public class ModifierSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			Entities.ForEach((Entity e,
				ref ModifierComponent modifierComponent,
				ref DurationComponent durationComponent) =>
			{
				ModifierState state = modifierComponent.modifierState;
				bool isEnd = durationComponent.isEnd;
				bool activeNeed = modifierComponent.needActive;
				bool isStartDuration = false;
				switch (state)
				{
					case ModifierState.Before:
						state = ModifierState.Active;
						break;
					case ModifierState.Active:
					{
						if (isEnd) state = ModifierState.After;
						break;
					}
					case ModifierState.After:
						state = ModifierState.Inactive;
						break;
					case ModifierState.Inactive:
					{
						if (activeNeed)
						{
							state = ModifierState.Before;
							isStartDuration = true;
							modifierComponent.needActive = false;
						}
						break;
					}
					default:
						throw new ArgumentOutOfRangeException();
				}

				if (isStartDuration)
					durationComponent.isStartNeeded = true;
				modifierComponent.modifierState = state;
			});
				
		}
	}
}