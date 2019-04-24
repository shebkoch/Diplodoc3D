using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Enemy
{
	public class ExplodeEnemyComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public float distance;
		public int damage;
		

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new ExplodeEnemyComponent
			{
				distance = distance,
				damage = damage,

			};
			dstManager.AddComponentData(entity, data);
		}
	}
}