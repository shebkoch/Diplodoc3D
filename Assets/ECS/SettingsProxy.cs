using Unity.Entities;
using UnityEngine;

namespace ECS
{
	public class SettingsProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public static Entity entity;
		public void Convert(Entity _entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			entity = _entity;
		}
	}
}