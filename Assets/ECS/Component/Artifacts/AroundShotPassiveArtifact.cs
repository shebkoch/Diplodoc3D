using ECS.Component.Stats;
using ECS.System.Stats;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Unity.Entities;

namespace ECS.Component.Artifacts
{
	public struct AroundShotPassiveArtifact : ISharedComponentData
	{
		public Entity bullet;
		public float speed;
		public int2 bulletCount;
	}
}