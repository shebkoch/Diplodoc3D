using System.Collections.Generic;
using ECS.Component.Artifacts.Common;
using ECS.Component.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
	public class UIShowArtifacts : MonoBehaviour
	{
		public List<Image> activeImages;
		public List<TextMeshProUGUI> texts;
		public List<Image> passiveImages;
		public List<TextMeshProUGUI> passiveTexts;

		private bool isActive = false;
		private void Update()
		{
			Time.timeScale = 0.001f;
			if (Input.anyKey)
			{
				Time.timeScale = 1;
				gameObject.SetActive(false);
				
			}
			if (!isActive)
			{
				ArtifactsPoolComponent artifactsPoolComponent = FindObjectOfType<ArtifactsPoolComponent>();
				List<GameObject> active = artifactsPoolComponent.active;
				List<GameObject> passive = artifactsPoolComponent.passive;
				if(active == null || active.Count == 0) return;

				ShowArtifact(active, texts, activeImages);
				ShowArtifact(passive, passiveTexts, passiveImages);
				isActive = true;
			}
		}

		private void ShowArtifact(List<GameObject> gameObjects, List<TextMeshProUGUI> texts, List<Image> images)
		{
			for (var i = 0; i < gameObjects.Count; i++)
			{
				var artifactInfo = gameObjects[i].GetComponent<ArtifactInfo>();
				images[i].sprite = artifactInfo.sprite;
				texts[i].text = artifactInfo.artifactName;	
			}
		}
	}
}