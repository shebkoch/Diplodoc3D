using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Unity.Entities;

namespace ECS.Component.Artifacts
{
	public struct ArthurStoneArtifact : IComponentData
	{
		public float minDistance;
		public float maxDistance;
		public float2 swordPosition;
		public GameObject marker;
		public GameObject sword;
	}
}