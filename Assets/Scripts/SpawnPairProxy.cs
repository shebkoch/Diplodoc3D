using System;
using Unity.Entities;
using UnityEngine;

[Serializable]
public class SpawnPairProxy
{
	public GameObject prefab;
	public int count;

	public SpawnPair Convert(GameObjectConversionSystem conversionSystem)
	{
		var data = new SpawnPair
		{
			prefab =  GameObjectConversionUtility.ConvertGameObjectHierarchy(prefab, World.Active),
			count = count
		};
		return data;
	}
}