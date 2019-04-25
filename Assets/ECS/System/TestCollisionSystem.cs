using ECS.Component;
using ECS.Component.Creatures;
using ECS.Component.Flags;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Systems;
using UnityEngine;

namespace ECS.System
{
	public unsafe class TestCollisionSystem : ComponentSystem
	{

		protected override void OnUpdate()
		{
			var physicsWorldSystem = World.Active.GetExistingSystem<BuildPhysicsWorld>();
			var collisionWorld = physicsWorldSystem.PhysicsWorld.CollisionWorld;
			
			Entity collisionEntity = Entity.Null;
			Entities.ForEach((Entity e,
				ref PhysicsCollider physicsCollider,
				ref PlayerPosition playerPosition) =>
			{
				ColliderCastInput colliderCastInput = new ColliderCastInput()
				{
					Collider = physicsCollider.ColliderPtr,
					Position = playerPosition.position,
					Direction = playerPosition.position,
					Orientation = quaternion.identity
				};
				ColliderCastHit hit = new ColliderCastHit();
				bool haveHit = collisionWorld.CastCollider(colliderCastInput, out hit);
				if (haveHit)
				{
					collisionEntity = physicsWorldSystem.PhysicsWorld.Bodies[hit.RigidBodyIndex].Entity;
				}
			});
			Debug.Log(collisionEntity);
		}
	}
	
}