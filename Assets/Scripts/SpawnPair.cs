using System;
using Unity.Entities;
using UnityEngine;

[Serializable]
public struct SpawnPair
{
	public GameObject prefab;
	public int count;
}

public struct EntitySpawnPair
{
	public Entity prefab;
	public int count;
}

[Serializable]
public struct HybridSpawnPair
{
	public Entity entity;
	public GameObject gameObject;
	public int count;
}
