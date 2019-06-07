using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Items
{
	public struct PickUpComponent : IComponentData
	{
		public GameObject picker;

		//work only on player based on physic layer
		private void OnTriggerEnter2D(Collider2D other)
		{
			picker = other.gameObject;
		}
	}
}