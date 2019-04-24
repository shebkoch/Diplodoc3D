using System;
using Unity.Entities;

namespace ECS.Component.Relations
{
	[Serializable]
	public struct PlayerFollowComponent : IComponentData
	{
		public float offset;
		public bool offsetEnable;
		public float distanceToPlayer;
	}
}