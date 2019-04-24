using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Creatures
{
	public class ParametersComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public int health;
		public int maxHealth;
		

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new ParametersComponent
			{
				health = health,
				maxHealth = maxHealth,
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}