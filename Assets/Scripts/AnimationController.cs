using ECS.Component.Creatures;
using ECS.Component.Settings;
using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace
{
	public class AnimationController : MonoBehaviour, IConvertGameObjectToEntity
	{
		public Entity animationEntity;
		public Animator animator;

		public string runStateName;
		public string idleStateName;
		public string attackStateName;

		private EntityManager entityManager;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			animationEntity = entity;
			var data = new AnimatorComponent
			{
			};
			dstManager.AddComponentData(entity, data);
		}

		private void Start()
		{
			entityManager =	World.Active.EntityManager;
		}

		private void Update()
		{
			AnimatorComponent  animatorComponent = entityManager.GetComponentData<AnimatorComponent>(animationEntity);
			if (animatorComponent.isAttackNeeded)
			{
				animator.SetTrigger(attackStateName);
			}
			else
			{
				animator.SetTrigger(animatorComponent.run ? runStateName : idleStateName);
			}
		}
	}
}