using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Artifacts.Common;
using ECS.Component.Artifacts.Util;
using ECS.Component.UI;
using Unity.Entities;

namespace ECS.System.Artifacts
{
[DisableAutoCreation]	public class LuckArtifactSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			int chanceAdd = GetSingleton<LuckArtifact>().chance;

			Entities.ForEach((Entity e,
				ref ArtifactComponent artifactComponent,
				ref ChanceArtifactComponent chanceArtifactComponent) =>
			{
				int chance = chanceArtifactComponent.chance;

				chance += chanceAdd;

				chanceArtifactComponent.chance = chance;
			});
			Enabled = false;
		}
	}
}