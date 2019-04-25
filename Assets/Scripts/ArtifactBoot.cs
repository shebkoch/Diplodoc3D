using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.UI;
using ECS.Component.Artifacts.Common;
using ECS.Component.UI;
using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class ArtifactBoot : MonoBehaviour
{
	private void Start()
	{
		var artifactsPoolComponent = FindObjectOfType<ArtifactsPoolComponent>();
			
		List<GameObject> activeArtifacts = artifactsPoolComponent.activePool;
		List<GameObject> passiveArtifacts = artifactsPoolComponent.passivePool;
		int passiveCount = artifactsPoolComponent.passiveCount;
		int activeCount = artifactsPoolComponent.activeCount;
		Random random = Rand.GetRandom();
		List<GameObject> active = new List<GameObject>();
		List<GameObject> passive = new List<GameObject>();
		var entityManager = World.Active.EntityManager;
			

		for (byte i = 0; i < passiveCount; i++)
		{	
			int randId = random.NextInt(passiveArtifacts.Count);
			GameObject prefabObject = passiveArtifacts[randId];
			Entity prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(passiveArtifacts[randId], World.Active);
			var instance = entityManager.Instantiate(prefab);
			passiveArtifacts.RemoveAt(randId);
			entityManager.SetComponentData(instance, new ArtifactComponent {id = i});

			passive.Add(prefabObject);
		}

		List<UIArtifactCooldownComponent> artifactsCooldown = FindObjectsOfType<UIArtifactCooldownComponent>().ToList();
		artifactsCooldown.Sort((x, y) => x.index.CompareTo(y.index));
		for (byte i = 0; i < activeCount; i++)
		{
			int randId = random.NextInt(activeArtifacts.Count);
			GameObject prefabObject = activeArtifacts[randId];
			Entity prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(prefabObject, World.Active);
			Entity instance = entityManager.Instantiate(prefab);

			artifactsCooldown[i].entity = instance;
			artifactsCooldown[i].cooldownImage.sprite = prefabObject.GetComponent<ArtifactInfo>().sprite;
			activeArtifacts.RemoveAt(randId);
			entityManager.SetComponentData(instance, new ArtifactComponent {id = i});
			active.Add(prefabObject);
		}

		artifactsPoolComponent.active = active;
		artifactsPoolComponent.passive = passive;
	}
}