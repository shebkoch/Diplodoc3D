using Unity.Entities;
using UnityEngine;

namespace ECS.Component
{
	public class CooldownComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public float cooldown;
		public bool canUse;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new CooldownComponent
			{
				cooldown = cooldown,
				canUse = canUse,
				last = float.MinValue
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}