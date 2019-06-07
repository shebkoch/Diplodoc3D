using System.Collections.Generic;
using ECS.Component;
using ECS.Component.Artifacts.Call;
using Unity.Entities;
using Unity.Mathematics;

namespace ECS.System.Artifacts.Call
{
	[DisableAutoCreation]
	public class CallArtifactSystem : ComponentSystem
	{
		protected struct Artifact
		{
			public CallArtifactComponent callArtifactComponent;
		}

		protected override void OnUpdate()
		{
			List<SpawnHelper> spawnHelpers = new List<SpawnHelper>();
			Entities.ForEach((Entity e,
				CallArtifactComponent callArtifactComponent) =>
			{
				bool isCallNeeded = callArtifactComponent.isCallNeeded;
				if (!isCallNeeded) return;

				int count = callArtifactComponent.count;
				Entity prefab = callArtifactComponent.calling;
				float3 position = callArtifactComponent.position;

				spawnHelpers.Add(
					new SpawnHelper
					{
						spawnPair = new EntitySpawnPair {prefab = prefab, count = count},
						prefabComponent = new PrefabComponent()
						{
							position = position
						},
					});

				callArtifactComponent.isCallNeeded = false;
				PostUpdateCommands.SetSharedComponent(e, callArtifactComponent);
			});

			Entities.ForEach((Entity e,
				SpawnComponent spawnComponent) =>
			{
				spawnComponent.list.AddRange(spawnHelpers);
				EntityManager.SetSharedComponentData(e, spawnComponent);
			});
		}
	}
}