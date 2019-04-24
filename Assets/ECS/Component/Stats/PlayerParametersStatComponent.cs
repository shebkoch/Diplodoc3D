using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Entities;

namespace ECS.Component.Stats
{
	public struct PlayerParametersStatComponent : IComponentData
	{
		public int lastHp;
		public int lastReceived;
	}
}