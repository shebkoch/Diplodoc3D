using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Creatures
{
	public class AnimatorComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public bool isAnimationNeeded;
		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new AnimatorComponent
			{
				isAttackNeeded = isAnimationNeeded,
			};
			dstManager.AddComponentData(entity, data);
		}
	}
}