using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts.Util
{
	public class ChanceByHpLoseComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new ChanceByHpLoseComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}