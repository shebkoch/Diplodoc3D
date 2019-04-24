using System.Collections.Generic;
using ECS.Component;
using ECS.Component.Damage;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
[DisableAutoCreation]	public class DeathSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			Entities.ForEach((Entity e,
				ref DeathComponent deathComponent) =>
			{
				if(deathComponent.isDeathNeed)
					PostUpdateCommands.DestroyEntity(e);
			});
		}
	}
}