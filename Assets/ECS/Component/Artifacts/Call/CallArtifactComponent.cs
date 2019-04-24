using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Unity.Entities;

namespace ECS.Component.Artifacts.Call
{
	public struct CallArtifactComponent : ISharedComponentData
	{
		public Entity calling;
		public bool isCallNeeded;
		public int count;
		public float3 position;
	}
}
