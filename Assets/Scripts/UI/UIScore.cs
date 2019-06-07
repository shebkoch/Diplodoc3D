using ECS;
using TMPro;
using Unity.Entities;
using UnityEngine;

namespace UI
{
	public class UIScore : MonoBehaviour
	{
		public TextMeshProUGUI text;
		public static int score;
		private void Update()
		{
			score = World.Active.EntityManager.GetComponentData<DeathCountComponent>(SettingsProxy.entity).count * 100;
			text.text = "" + score;
		}
	}
}