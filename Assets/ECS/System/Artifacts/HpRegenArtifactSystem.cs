using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Artifacts.Common;
using ECS.Component.Creatures;
using ECS.Component.Flags;
using Unity.Entities;

namespace ECS.System.Artifacts
{
	public class HpRegenArtifactSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			bool enable = false;
			Entities.ForEach((Entity e,
				ref ArtifactUsingComponent artifactUsingComponent,
				ref HpRegenArtifact hpRegenArtifact,
				ref CooldownComponent cooldownComponent) =>
			{
				bool isCastNeeded = artifactUsingComponent.isCastNeeded;
				if(!isCastNeeded) return;
				enable = cooldownComponent.canUse;
				if (enable)
				{
					cooldownComponent.isReloadNeeded = true;
				}
			});
			if(!enable) return;
			Entities.ForEach((Entity e,
				ref PlayerTag playerTag,
				ref ParametersComponent parametersComponent) =>
			{
				parametersComponent.health = parametersComponent.maxHealth;

			});
		}
	}
}