using Unity.Entities;

namespace ECS.Component
{
	public struct DurationComponent : IComponentData
	{
		public bool isEnd;
		public float duration;
		public float last;
		public bool isStartNeeded;
	}
}