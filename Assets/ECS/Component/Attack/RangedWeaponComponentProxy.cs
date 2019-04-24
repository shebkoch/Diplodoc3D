using Structures;
using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Attack
{
	public class RangedWeaponComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public RangedWeapon rangedWeapon;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new RangedWeaponComponent
			{
				rangedWeapon = rangedWeapon,
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}