using ECS.Component;
using ECS.Component.Attack;
using ECS.Component.Flags;
using ECS.Component.Settings;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	public class MouseControllerSystem : ComponentSystem
	{	
		protected override void OnUpdate()
		{
			float3 mousePos = float3.zero;
			Entities.ForEach((Entity e,
				ref InputMouseComponent inputMouseComponent,
				ref InputAttackComponent inputAttackComponent) =>
			{
				mousePos = inputMouseComponent.mousePosition;
				MouseKeyState rightState = inputMouseComponent.rightState;
				MouseKeyState leftState = inputMouseComponent.leftState;

				bool rangedPress = leftState == MouseKeyState.Down;
				bool meleePress = rightState == MouseKeyState.Down;

				inputAttackComponent.rangedPress = rangedPress;
				inputAttackComponent.meleePress = meleePress;
			});
			Entities.ForEach((Entity e,
				ref PlayerTag playerTag,
				ref RangedAttackComponent rangedAttackComponent) =>
			{
				rangedAttackComponent.endPoint = mousePos;
			});
		}
	}
}