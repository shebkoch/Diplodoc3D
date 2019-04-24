using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.Serialization;

namespace ECS.Component.Enemy
{
	public struct EnemyGeneratorComponent : ISharedComponentData 
	{
		public int wave;
		public int breakAfter;
		public int wavePlus;
		public int countSpread;
		public float2 positionSpread;
//public List<SpawnPair> enemies;
		public List<SpawnPair> enemies;
	}
}