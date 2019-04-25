using System.Collections.Generic;
using System.Linq;
using ECS.Component;
using ECS.Component.Artifacts.Common;
using ECS.Component.UI;
using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace.UI
{
	public class UIArtifactCooldown : MonoBehaviour
	{
		public UIArtifactCooldownComponent uiArtifactCooldownComponent;

		private void Update()
		{
			EntityManager entityManager = World.Active.EntityManager;
			CooldownComponent cooldownComponent = entityManager.GetComponentData<CooldownComponent>(uiArtifactCooldownComponent.entity);
			
			var currentTime = Time.realtimeSinceStartup;

			float fill = 1;
			if (!cooldownComponent.canUse)
				fill = (currentTime - cooldownComponent.last) / cooldownComponent.cooldown;
			uiArtifactCooldownComponent.cooldownImage.fillAmount = fill;
		}
	}
}