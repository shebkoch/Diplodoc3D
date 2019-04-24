using System.Collections.Generic;
using ECS.Component.Artifacts.Common;
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
			Entity prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(activeArtifacts[randId], World.Active);
			var instance = entityManager.Instantiate(prefab);
			passiveArtifacts.RemoveAt(randId);
			entityManager.SetComponentData(instance, new ArtifactComponent {id = i});

			passive.Add(gameObject);
		}
			
		for (byte i = 0; i < activeCount; i++)
		{
			int randId = random.NextInt(activeArtifacts.Count);
			Entity prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(passiveArtifacts[randId], World.Active);
			var instance = entityManager.Instantiate(prefab);

			activeArtifacts.RemoveAt(randId);
			entityManager.SetComponentData(instance, new ArtifactComponent {id = i});
			active.Add(gameObject);
		}

		artifactsPoolComponent.active = active;
		artifactsPoolComponent.passive = passive;
	}
}