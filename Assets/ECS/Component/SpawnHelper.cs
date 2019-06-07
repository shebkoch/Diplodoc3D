using System;

namespace ECS.Component
{
	[Serializable]
	public struct SpawnHelper
	{
		public PrefabComponent prefabComponent;

		public EntitySpawnPair spawnPair;

		public bool hybrid;
		public HybridSpawnPair hybridSpawnPair;
	}
}