using System.Collections.Generic;
using ECS.Component;
using ECS.Component.Damage;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

namespace ECS.System
{
	public class DeathSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			Entities.ForEach((Entity e,
				ref DeathComponent deathComponent) =>
			{
				if (deathComponent.isDeathNeed)
				{
					PostUpdateCommands.DestroyEntity(e);
					var buffer = EntityManager.GetBuffer<Child>(e);
					for (var i = 0; i < buffer.Length; i++)
					{
						PostUpdateCommands.DestroyEntity(buffer[i].Value);
					}
				}
			});
		}
	}
}