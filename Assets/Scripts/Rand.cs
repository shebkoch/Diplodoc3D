using System;
using Unity.Mathematics;
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

	public static float3 OnCircle3D(Random random, float y, float3 radius, float min, float max)
	{
		float2 circleNormalized = random.NextFloat2Direction();
		float3 randomPos = new float3(circleNormalized.x, y, circleNormalized.y) * (radius + 
		                                                                            random.NextFloat(-min,max));
		return randomPos;	
	}
	public static float3 OnCircle3D(float y, float3 radius, float min, float max)
	{
		return OnCircle3D(GetRandom(), y, radius, min, max);
	}
}