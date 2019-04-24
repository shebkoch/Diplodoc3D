using Unity.Entities;

namespace ECS.Component.Flags
{
	public struct CameraTag : IComponentData
	{
		public bool isEnable;
	}
}