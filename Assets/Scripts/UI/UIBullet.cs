using ECS.Component.Attack;
using ECS.Component.Flags;
using TMPro;
using Unity.Entities;
using UnityEngine;

namespace UI
{
	public class UIBullet : MonoBehaviour
	{
		public TextMeshProUGUI bulletCountText;

		private void Update()
		{
			int bulletCount = World.Active.EntityManager.GetComponentData<RangedWeaponComponent>(PlayerTagProxy.playerEntity).rangedWeapon.bulletCount;
			bulletCountText.text = bulletCount.ToString();
		}
	}
}