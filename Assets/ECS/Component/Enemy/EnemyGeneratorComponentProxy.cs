using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Enemy
{
	public class EnemyGeneratorComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public int breakAfter;
		public int wavePlus;
		public int spread;
		public List<SpawnPairProxy> enemies;
		

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			List<SpawnPair> enemiesEntity = new List<SpawnPair>();
			foreach (var enemy in enemies) enemiesEntity.Add(enemy.Convert(conversionSystem));
			
			var data = new EnemyGeneratorComponent
			{
				breakAfter = breakAfter,
				wavePlus = wavePlus,
				countSpread = spread,
				enemies = enemiesEntity
			};
			dstManager.AddSharedComponentData(entity, data);
		}
	}
}