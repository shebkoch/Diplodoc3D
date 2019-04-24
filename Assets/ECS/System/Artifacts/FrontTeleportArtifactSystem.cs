using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Artifacts.Common;
using ECS.Component.Flags;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace ECS.System.Artifacts
{
[DisableAutoCreation]    public class FrontTeleportArtifactSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            float3 position = new float3();
            float3 up = new float3();
            Entities.ForEach((Entity e,
                ref PlayerTag playerTag,
                ref Translation translation) =>
            {
                position = translation.Value;
                up = math.up();
            });

            float3 location = new float3();
            bool canUse = false;

            Entities.ForEach((Entity e,
                ref ArtifactUsingComponent artifactUsingComponent,
                ref FrontTeleportArtifact frontTeleportArtifactSystem,
                ref TeleportArtifact teleportArtifact,
                ref CooldownComponent cooldownComponent) =>
            { 
                canUse = artifactUsingComponent.canUse;
                if(!canUse) return;

                float distance = frontTeleportArtifactSystem.distance;
                
                location = position + new float3(up * distance);
                                  
                cooldownComponent.isReloadNeeded = true;
                artifactUsingComponent.canUse = false;
                teleportArtifact.location = location;
                teleportArtifact.active = true;
            });
                

            if(!canUse) return;
            Entities.ForEach((Entity e,
                ref CameraComponent cameraComponent,
                ref Translation translation) =>
            {
                translation.Value = new float3(location.xy,translation.Value.z);
            });
                
            
        }
    }
}