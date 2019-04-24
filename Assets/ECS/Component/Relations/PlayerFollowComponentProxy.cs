using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Relations
{
	public class PlayerFollowComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public float offset;
		public bool offsetEnable;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new PlayerFollowComponent
			{
				offset = offset,
				offsetEnable = offsetEnable
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}