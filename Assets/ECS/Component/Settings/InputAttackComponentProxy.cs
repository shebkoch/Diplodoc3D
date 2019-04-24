using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Settings
{
	public class InputAttackComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new InputAttackComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}