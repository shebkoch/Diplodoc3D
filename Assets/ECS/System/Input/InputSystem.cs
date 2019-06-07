using ECS.Component.Settings;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Input
{	
	public class InputSystem : ComponentSystem
		{
			protected override void OnUpdate()
			{
				Entities.ForEach((Entity e,
					ref InputUseComponent inputUseComponent,
					ref InputMovementComponent inputMovement,
					ref InputMouseComponent inputMouse) =>
				{
					string horizontalAxisName = "Horizontal";
					string verticalAxisName = "Vertical";
					float holdTime = inputMouse.holdTime;
					float startHold = inputMouse.startHold;

					float horizontal = UnityEngine.Input.GetAxis(horizontalAxisName);
					float vertical = UnityEngine.Input.GetAxis(verticalAxisName);

					bool use1ButtonDown = UnityEngine.Input.GetKey(KeyCode.Alpha1);
					bool use2ButtonDown = UnityEngine.Input.GetKey(KeyCode.Alpha2);
					float3 mousePosition = UnityEngine.Input.mousePosition;
					mousePosition.x -= (float) Screen.width / 2;
					mousePosition.y -= (float) Screen.height / 2;

					bool leftDown = UnityEngine.Input.GetMouseButton(0);
					bool rightDown = UnityEngine.Input.GetMouseButton(1);
					MouseKeyState leftState = leftDown ? MouseKeyState.Down : MouseKeyState.Up;
					MouseKeyState rightState = rightDown ? MouseKeyState.Down : MouseKeyState.Up;
					if (leftDown && startHold <= 0) startHold = Time.realtimeSinceStartup;
					if (leftDown && startHold >= 0) holdTime = Time.realtimeSinceStartup - startHold;
					if (!leftDown)
					{
						holdTime = -1;
						startHold = -1;
					}

					inputMovement.horizontal = horizontal;
					inputMovement.vertical = vertical;
					inputMouse.mousePosition = mousePosition;
					inputMouse.leftState = leftState;
					inputMouse.rightState = rightState;
					inputMouse.holdTime = holdTime;
					inputMouse.startHold = startHold;
					inputUseComponent.use1ButtonDown = use1ButtonDown;
					inputUseComponent.use2ButtonDown = use2ButtonDown;
				});
			}
		}
	}