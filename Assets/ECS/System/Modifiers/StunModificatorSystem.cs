using ECS.Component.Creatures;
using ECS.Component.Modificators;
using ECS.System.Relations;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace ECS.System.Modifiers
{
	[UpdateAfter(typeof(PlayerFollowSystem))] 
	public class StunModificatorSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			Entities.ForEach((Entity e,
				ref StunModificatorComponent stunModificatorComponent) =>
			{
				bool isEnable = stunModificatorComponent.isEnable;
				
				if(!isEnable) return;

				float last = stunModificatorComponent.last;
				float duration = stunModificatorComponent.duration;
				float currentTime = Time.realtimeSinceStartup;
				if (last + duration < currentTime) isEnable = false;

				float fillAmount = 1 - (currentTime - last) / duration;

				stunModificatorComponent.fillAmount = fillAmount;
				stunModificatorComponent.isEnable = isEnable;
			});
			Entities.ForEach((Entity e,
				ref StunModificatorComponent stunModificatorComponent,
				ref MovingComponent movingComponent) =>
			{
				if(!stunModificatorComponent.isEnable) return;
				
				movingComponent.vertical = 0;
				movingComponent.horizontal = 0;
			});

			Entities.ForEach((Entity e,
				ref StunModificatorComponent stunModificatorComponent,
				ref RotationComponent rotationComponent) =>
			{
				bool isStunEnable = stunModificatorComponent.isEnable;
				rotationComponent.isEnable = !isStunEnable;
			});
			
		}

		
	}
}