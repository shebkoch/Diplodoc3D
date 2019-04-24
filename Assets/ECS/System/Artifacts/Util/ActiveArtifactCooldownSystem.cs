using ECS.Component;
using ECS.Component.Artifacts.Common;
using Unity.Entities;

namespace ECS.System.Artifacts.Util
{
[DisableAutoCreation]	public class ActiveArtifactCooldownSystem : ComponentSystem
	{

		protected override void OnUpdate(){

			Entities.ForEach((Entity e,
				ref ArtifactUsingComponent artifactUsingComponent,
				ref CooldownComponent cooldownComponent) =>
			{
				bool isCastNeeded = artifactUsingComponent.isCastNeeded;
				if(!isCastNeeded) return;
				bool enable = cooldownComponent.canUse;
				if (enable) artifactUsingComponent.canUse = true;
			});
		}
	}
}