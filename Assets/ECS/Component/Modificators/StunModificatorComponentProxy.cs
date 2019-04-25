using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Modificators
{
	public class StunModificatorComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new StunModificatorComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}