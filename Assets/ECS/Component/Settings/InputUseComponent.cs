using Unity.Entities;

namespace ECS.Component.Settings
{
	public struct InputUseComponent : IComponentData
	{
		public bool use1ButtonDown;
		public bool use2ButtonDown;
	}
}