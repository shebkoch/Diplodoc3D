using ECS.Component.Artifacts.Common;
using ECS.Component.Settings;
using Unity.Entities;

namespace ECS.System.Input
{
	public class PlayerUseSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			bool use1ButtonDown = false;
			bool use2ButtonDown = false;
			Entities.ForEach((Entity entity, 
					ref InputUseComponent inputUseComponent) =>
				{
					use1ButtonDown = inputUseComponent.use1ButtonDown;
					use2ButtonDown = inputUseComponent.use2ButtonDown;
				} 
			);
			Entities.ForEach((Entity entity, 
					ref ArtifactComponent artifactComponent,
					ref ArtifactUsingComponent artifactUsingComponent) =>
				{
					switch (artifactComponent.id)
					{
						case 0:
							artifactUsingComponent.isCastNeeded = use1ButtonDown;
							break;
						case 1:
							artifactUsingComponent.isCastNeeded = use2ButtonDown;
							break;
					}
				} 
			);
		}
	}
}