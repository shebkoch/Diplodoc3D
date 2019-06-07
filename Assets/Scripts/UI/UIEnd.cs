using ECS.Component.Creatures;
using ECS.Component.Flags;
using TMPro;
using Unity.Entities;
using UnityEngine;

namespace UI
{
	public class UIEnd : MonoBehaviour
	{
		public TextMeshProUGUI score;
		public GameObject panel;

		private void Update()
		{
			if(Input.GetKeyUp(KeyCode.Escape)) Application.Quit(); 
			if (World.Active.EntityManager.GetComponentData<ParametersComponent>(PlayerTagProxy.playerEntity).health <= 0)
			{
				panel.SetActive(true);
				score.text = UIScore.score.ToString();
				World.Active.Dispose();
			}
		}
	}
}