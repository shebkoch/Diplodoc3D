﻿using System;
using Unity.Entities;

namespace ECS.Component.Creatures
{
	[Serializable]
	public struct MovingComponent : IComponentData
	{
		public float horizontal;
		public float speed;
		public float vertical;
	}
}