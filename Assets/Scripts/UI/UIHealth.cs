using ECS.Component.Creatures;
using ECS.Component.UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class UIHealth : MonoBehaviour
	{
		private Image image;
		private float maxHealth;
		public ParametersComponent playerParameters;
		public UIHealthComponent uiHealthComponent;

		private void Start()
		{
			maxHealth = playerParameters.maxHealth;
			image = uiHealthComponent.image;
		}

		private void Update()
		{
			image.fillAmount = playerParameters.health / maxHealth;
		}
	}
}