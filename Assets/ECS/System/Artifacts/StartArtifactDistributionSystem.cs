using ECS.Component.Artifacts.Common;
using Unity.Entities;

namespace ECS.System.Artifacts
{
	
[DisableAutoCreation]	public class StartArtifactDistributionSystem : ComponentSystem
	{
		protected struct Pool
		{
			public ArtifactsPoolComponent artifactsPoolComponent;
		}

		protected override void OnUpdate()
		{
			
		}
	}
}