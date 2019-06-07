using System;
using Unity.Entities;
using UnityEngine;

[Serializable]
public class HybridSpawnPairProxy
{
	public GameObject entity;
	public GameObject prefab;
	public int count;

	public HybridSpawnPair Convert()
	{
		var data = new HybridSpawnPair
		{
			entity = GameObjectConversionUtility.ConvertGameObjectHierarchy(entity, World.Active),
			gameObject = prefab,
			count = count
		};
		
		return data;
	}
}