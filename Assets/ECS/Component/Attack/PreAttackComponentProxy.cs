using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Attack
{
	public class PreAttackComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new PreAttackComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}