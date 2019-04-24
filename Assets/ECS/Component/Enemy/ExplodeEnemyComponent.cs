using Unity.Mathematics;
using UnityEngine;using Unity.Entities;

namespace ECS.Component.Enemy
{
	public struct ExplodeEnemyComponent : IComponentData
	{
		public float distance;
		public int damage;
		public GameObject particle;
	}
}