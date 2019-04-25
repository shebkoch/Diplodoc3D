using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace ECS.Component.UI
{
	public class UIArtifactCooldownComponent : MonoBehaviour
	{
		public Image cooldownImage;
		public Entity entity;
		public byte index;
	}
}