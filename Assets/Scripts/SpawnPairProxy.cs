using System;
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
			prefab =  prefab,
			count = count
		};
		return data;
	}
}