using ECS.Component.Creatures;
using ECS.Component.Flags;
using ECS.Component.UI;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class UIHealth : MonoBehaviour
	{
		private float maxHealth;		
		public Image image;
		private void Start()
		{
			maxHealth = World.Active.EntityManager.GetComponentData<ParametersComponent>(PlayerTagProxy.playerEntity).maxHealth;
		}

		private void Update()
		{
			float health =
				World.Active.EntityManager.GetComponentData<ParametersComponent>(PlayerTagProxy.playerEntity).health;
			image.fillAmount = health / maxHealth;
		}
	}
}