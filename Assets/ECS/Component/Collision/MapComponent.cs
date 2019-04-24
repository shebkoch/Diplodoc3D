using Structures;
using Unity.Entities;

namespace ECS.Component.Collision
{
	public struct MapComponent : IComponentData
	{
		public entity4[,] map;
	}
}