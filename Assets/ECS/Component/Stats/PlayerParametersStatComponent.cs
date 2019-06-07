using Unity.Entities;

namespace ECS.Component.Stats
{
	public struct PlayerParametersStatComponent : IComponentData
	{
		public int lastReceived;
	}
}