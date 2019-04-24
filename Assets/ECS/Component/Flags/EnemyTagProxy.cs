using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Flags
{
	public class EnemyTagProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new EnemyTag
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}