using ECS.Component;
using ECS.Component.Artifacts.Call;
using ECS.Component.Artifacts.Common;
using ECS.Component.Flags;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS.System.Artifacts.Call
{
[DisableAutoCreation]	public class PlayerCallArtifactSystem : ComponentSystem
	{

		protected override void OnUpdate()
		{
			float3 position = 0;
			Entities.ForEach((Entity e,
				ref PlayerTag playerTag,
				ref Translation translation) =>
			{
				position = translation.Value;
			});
			Entities.ForEach((Entity e,
				CallArtifactComponent callArtifactComponent,
				ref ArtifactUsingComponent artifactUsingComponent,
				ref PlayerCallArtifactComponent playerCallArtifactComponent,
				ref CooldownComponent cooldownComponent) =>
			{
				bool enable = artifactUsingComponent.canUse;

				if (enable)
				{
					cooldownComponent.isReloadNeeded = true;
					callArtifactComponent.isCallNeeded = true;
					callArtifactComponent.position = position;
					PostUpdateCommands.SetSharedComponent(e, callArtifactComponent);
				}

				artifactUsingComponent.canUse = false;
			});
		}
	}
}