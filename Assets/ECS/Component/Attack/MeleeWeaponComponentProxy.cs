using Structures;
using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Attack
{
	public class MeleeWeaponComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public MeleeWeapon meleeWeapon;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new MeleeWeaponComponent
			{
				meleeWeapon = meleeWeapon,
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}