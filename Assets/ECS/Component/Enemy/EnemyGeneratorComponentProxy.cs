using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Enemy
{
	public class EnemyGeneratorComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public int breakAfter;
		public int wavePlus;
		public int spread;
		public List<HybridSpawnPairProxy> enemies;
		
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			List<HybridSpawnPair> list = new List<HybridSpawnPair>();
			foreach (var hybridSpawnPair in enemies)
			{
				list.Add(hybridSpawnPair.Convert());
			}
			var data = new EnemyGeneratorComponent
			{
				breakAfter = breakAfter,
				wavePlus = wavePlus,
				countSpread = spread,
				enemies = list
			};
			dstManager.AddSharedComponentData(entity, data);
		}
	}
}