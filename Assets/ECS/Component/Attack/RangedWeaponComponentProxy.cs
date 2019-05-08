using Structures;
using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Attack
{
	public class RangedWeaponComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public RangedWeapon rangedWeapon;
		public GameObject bullet;
		public Sprite sprite;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			rangedWeapon.bulletPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(bullet, World.Active);
			var data = new RangedWeaponComponent
			{
				isEnable = true,
				rangedWeapon = rangedWeapon,
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}