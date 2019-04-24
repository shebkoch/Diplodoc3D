using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECS.Component
{
	public class SpawnComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public List<SpawnHelper> list;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new SpawnComponent
			{
				list = list,
			};
			dstManager.AddSharedComponentData(entity, data);
		}
	}
}