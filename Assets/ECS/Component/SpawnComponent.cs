using System.Collections.Generic;
using Unity.Entities;

namespace ECS.Component
{
	public struct SpawnComponent : ISharedComponentData
	{
		public List<SpawnHelper> list;
	}
}