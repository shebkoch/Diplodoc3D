using ECS.Component;
using ECS.Component.Creatures;
using ECS.Component.Flags;
using ECS.Component.Stats;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Stats
{
	[DisableAutoCreation]	public class PlayerParametersStatSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			int hp = 0;
			Entities.ForEach((Entity e,
				ref PlayerTag playerTag,
				ref ParametersComponent parametersComponent) =>
			{
				hp = parametersComponent.health;
			});
			Entities.ForEach((Entity e,
				ref PlayerParametersStatComponent playerParametersStatComponent) =>
			{
				
				int last = playerParametersStatComponent.lastHp;
				int lastReceived = 0;
				if (last != 0) lastReceived = last - hp;
				playerParametersStatComponent.lastReceived = lastReceived;
				playerParametersStatComponent.lastHp = hp;

			});
		}
	}
}