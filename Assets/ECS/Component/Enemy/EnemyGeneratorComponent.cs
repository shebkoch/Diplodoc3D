using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;

namespace ECS.Component.Enemy
{
	public struct EnemyGeneratorComponent : ISharedComponentData 
	{
		public int wave;
		public int breakAfter;
		public int wavePlus;
		public int countSpread;
		public float2 positionSpread;
		public List<HybridSpawnPair> enemies;
	}
}