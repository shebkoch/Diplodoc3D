using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Attack.PreAttack
{
	public class AroundShotFlagProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new AroundShotFlag
			{
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}