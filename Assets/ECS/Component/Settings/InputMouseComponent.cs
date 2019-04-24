using Unity.Entities;
using Unity.Mathematics;

namespace ECS.Component.Settings
{
	public struct InputMouseComponent : IComponentData
	{
		public float holdTime;
		public MouseKeyState leftState;
		public float3 mousePosition;
		public MouseKeyState rightState;
		public float startHold;
	}
}