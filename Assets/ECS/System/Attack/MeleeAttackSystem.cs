using ECS.Component.Attack;
using ECS.Component.Creatures;
using Structures;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Collider = Unity.Physics.Collider;
using Unity.Physics.Systems;
using UnityEngine;

namespace ECS.System.Attack
{
    public unsafe class MeleeAttackSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            float3 playerPos = GetSingleton<PlayerPosition>().position;
            Entities.ForEach((Entity e,
                ref MeleeAttackComponent meleeAttackComponent,
                ref MeleeWeaponComponent meleeWeaponComponent,
                ref AnimatorComponent animator
                ) =>
            {
                MeleeWeapon weapon = meleeWeaponComponent.meleeWeapon;
                bool isAttackNeed = meleeAttackComponent.isAttackNeed;
                float currentTime = Time.realtimeSinceStartup;
                bool isAnimationNeeded = animator.isAnimationNeeded;
                bool enabled = false;

                if (isAttackNeed && weapon.lastAttack + weapon.cooldown <= currentTime)
                {
                    enabled = true;
                    weapon.lastAttack = currentTime;
                    isAnimationNeeded = true;
                }

                if (enabled)
                {
                    float3 position = playerPos + meleeAttackComponent.colliderRelativePosition;
                    ColliderCastInput colliderCastInput = new ColliderCastInput()
                    {
                        Collider = (Collider*) meleeAttackComponent.meleeCollider.GetUnsafePtr(),
                        Position = position,
                        Direction = position,
                        Orientation = quaternion.identity
                    };
                    var physicsWorldSystem = World.Active.GetExistingSystem<BuildPhysicsWorld>();
                    var collisionWorld = physicsWorldSystem.PhysicsWorld.CollisionWorld;

                    ColliderCastHit hit = new ColliderCastHit();
                    bool haveHit = collisionWorld.CastCollider(colliderCastInput, out hit);
                    if (haveHit)
                    {
                        Entity collisionEntity = physicsWorldSystem.PhysicsWorld.Bodies[hit.RigidBodyIndex].Entity;
                        ParametersComponent parametersComponent =
                            EntityManager.GetComponentData<ParametersComponent>(collisionEntity);
                        parametersComponent.health -= weapon.damage;
                        PostUpdateCommands.SetComponent(collisionEntity, parametersComponent);
                    }
                }

                meleeWeaponComponent.meleeWeapon = weapon;
                animator.isAnimationNeeded = isAnimationNeeded;
            });
        }
    }
}