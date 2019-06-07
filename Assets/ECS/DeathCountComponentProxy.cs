using Unity.Entities;
using UnityEngine;

namespace ECS
{
	public class DeathCountComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public int count;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new DeathCountComponent
			{
				count = count,
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}