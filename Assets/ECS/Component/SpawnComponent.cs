using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;

namespace ECS.Component
{
	public struct SpawnComponent : ISharedComponentData
	{
		public List<SpawnHelper> list;
	}
}