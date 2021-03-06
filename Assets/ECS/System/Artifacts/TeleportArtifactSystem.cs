using ECS.Component.Artifacts;
using ECS.Component.Flags;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS.System.Artifacts
{
	public class TeleportArtifactSystem : ComponentSystem
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