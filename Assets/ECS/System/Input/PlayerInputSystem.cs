using ECS.Component.Creatures;
using ECS.Component.Flags;
using ECS.Component.Settings;
using Unity.Entities;

namespace ECS.System.Input
{
	public class PlayerInputSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			float horizontal = 0;
			float vertical = 0;

			Entities.ForEach((Entity e,
				ref InputMovementComponent inputMovementComponent) =>
			{
				horizontal = inputMovementComponent.horizontal;
				vertical = inputMovementComponent.vertical;
			});
			Entities.ForEach((Entity e,
				ref PlayerTag playerTag,
				ref MovingComponent movingComponent) =>
			{
				movingComponent.horizontal = horizontal;
				movingComponent.vertical = vertical;
			});
		}


	}
}