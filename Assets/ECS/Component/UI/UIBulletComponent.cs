using UnityEngine;using Unity.Entities;
using UnityEngine.UI;

namespace ECS.Component.UI
{
	public struct UIBulletComponent : IComponentData
	{
		public Text bulletCountText;
	}
}