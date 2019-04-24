using Unity.Entities;
using UnityEngine.UI;

namespace ECS.Component.Modificators
{
	public struct StunModificatorComponent : IComponentData
	{
		public float duration;
		public bool isEnable;
		public float last;

		public Image indicator;
		public float fillAmount;
	}
}