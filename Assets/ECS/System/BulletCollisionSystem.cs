using ECS.Component;
using ECS.Component.Creatures;
using ECS.Component.Flags;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Systems;
using Unity.Transforms;
using UnityEngine;

namespace ECS.System
{
	public unsafe class BulletCollisionSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			var physicsWorldSystem = World.Active.GetExistingSystem<BuildPhysicsWorld>();
			var collisionWorld = physicsWorldSystem.PhysicsWorld.CollisionWorld;
			
			Entity collisionEntity;
			Entities.ForEach((Entity e,
				ref PhysicsCollider physicsCollider,
				ref PlayerBulletTag playerBulletTag,
				ref Translation translation) =>
			{
				ColliderCastInput colliderCastInput = new ColliderCastInput()
				{
					Collider = physicsCollider.ColliderPtr,
					Position = translation.Value,
					Direction = translation.Value,
					Orientation = quaternion.identity
				};
				ColliderCastHit hit = new ColliderCastHit();
				bool haveHit = collisionWorld.CastCollider(colliderCastInput, out hit);
				if (haveHit)
				{
					collisionEntity = physicsWorldSystem.PhysicsWorld.Bodies[hit.RigidBodyIndex].Entity;
					if (collisionEntity == Entity.Null) return;
					ParametersComponent parametersComponent =
						EntityManager.GetComponentData<ParametersComponent>(collisionEntity);
					parametersComponent.health--;
					PostUpdateCommands.SetComponent(collisionEntity, parametersComponent);
					PostUpdateCommands.DestroyEntity(e);
				}
			});
		}
	}
	
}