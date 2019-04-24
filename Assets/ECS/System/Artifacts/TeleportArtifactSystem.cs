using System;
using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Flags;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace ECS.System.Artifacts
{
[DisableAutoCreation]	public class TeleportArtifactSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			float3 location = new float3();
			bool active = false; 
			Entities.ForEach((Entity e,
				ref TeleportArtifact teleportArtifact) =>
			{
				active = teleportArtifact.active;
				if(!active) return;
				location = teleportArtifact.location;

				teleportArtifact.active = false;
			});
			if(!active) return;
			Entities.ForEach((Entity e,
				ref PlayerTag playerTag,
				ref Translation translation) =>
			{
				translation.Value = location;
			});
		}
	}
}