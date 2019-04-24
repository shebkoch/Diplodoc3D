using System;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public static class Rand
{
	public static Random GetRandom()
	{
		return new Random((uint) DateTime.Now.Ticks);
	}

	public static float3 OnCircle(float3 radius, float min, float max)
	{
		float3 randomPos = new float3(UnityEngine.Random.insideUnitCircle.normalized, 0) * (radius + 
		                   UnityEngine.Random.Range(-min,max));
		return randomPos;
	}

	//to math rand
	public static float3 OnCircle3D(float y, float3 radius, float min, float max)
	{
		float2 circleNormalized = UnityEngine.Random.insideUnitCircle.normalized;
		float3 randomPos = new float3(circleNormalized.x, y, circleNormalized.y) * (radius + 
		                                                                                    UnityEngine.Random.Range(-min,max));
		return randomPos;
	}
}