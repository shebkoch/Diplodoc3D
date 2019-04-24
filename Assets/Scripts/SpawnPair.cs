using System;
using Unity.Entities;

[Serializable]
public struct SpawnPair
{
	public Entity prefab;
	public int count;
}