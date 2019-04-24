using ECS.Component;
using ECS.Component.Artifacts;
using Unity.Entities;
using NotImplementedException = System.NotImplementedException;

namespace ECS.System.Artifacts
{
[DisableAutoCreation]	public class CooldownReduceSystem : ComponentSystem
	{
		protected struct Cooldown
		{
			public CooldownComponent cooldownComponent;
		}
		protected struct Artifact
		{
			public CooldownReduceArtifact cooldownReduceArtifact;
		}
		protected override void OnUpdate()
		{
			float percent = GetSingleton<CooldownReduceArtifact>().percent;
			
			Entities.ForEach((Entity e,
				ref CooldownComponent cooldownComponent) =>
			{
				cooldownComponent.cooldown *= percent;
			});

			this.Enabled = false;
		}
	}
}