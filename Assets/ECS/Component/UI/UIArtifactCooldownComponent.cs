using Unity.Entities;
using UnityEngine.UI;

namespace ECS.Component.UI
{
	public struct UIArtifactCooldownComponent : IComponentData
	{
		public Image cooldownImage;
		public byte id;
	}
}