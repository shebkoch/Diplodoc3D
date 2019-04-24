using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Settings
{
	public class InputUseComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new InputUseComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}