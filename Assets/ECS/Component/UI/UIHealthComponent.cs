using UnityEngine;using Unity.Entities;
using UnityEngine.UI;

namespace ECS.Component.UI
{
	public struct UIHealthComponent : IComponentData
	{
		public Image image;
	}
}