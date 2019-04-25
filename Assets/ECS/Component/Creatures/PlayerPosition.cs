using System.ComponentModel;
using Unity.Entities;
using Unity.Mathematics;

namespace ECS.Component.Creatures
{
	public struct PlayerPosition : IComponentData
	{
		public float3 position;
	}
}