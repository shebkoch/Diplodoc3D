using System.Collections.Generic;
using ECS.Component.Attack;
using ECS.Component.Creatures;
using Structures;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Collider = Unity.Physics.Collider;
using Unity.Physics.Systems;
using Unity.Transforms;
using UnityEngine;

namespace ECS.System.Attack
{
    public unsafe class MeleeAttackSystem : ComponentSystem
    {
        public static ColliderCastInput castInput;
        protected override void OnUpdate()
        {
            Entities.ForEach((Entity e,
                ref MeleeAttackComponent meleeAttackComponent,
                ref MeleeWeaponComponent meleeWeaponComponent,
                ref AnimatorComponent animator,
                ref Rotation rotation,
                ref Translation translation
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
                    float3 position = translation.Value + math.mul(rotation.Value, meleeAttackComponent.colliderRelativePosition);
                    ColliderCastInput colliderCastInput = new ColliderCastInput()
                    {
                        Collider = (Collider*) meleeAttackComponent.meleeCollider.GetUnsafePtr(),
                        Position = position,
                        Direction = new float3(0,0,-1),
                        Orientation = rotation.Value
                    };
                    castInput = colliderCastInput;
                    var physicsWorldSystem = World.Active.GetExistingSystem<BuildPhysicsWorld>();
                    var collisionWorld = physicsWorldSystem.PhysicsWorld.CollisionWorld;

                    NativeList<ColliderCastHit> colliderCastHits =
                        new NativeList<ColliderCastHit>(Allocator.Persistent);

                    collisionWorld.CastCollider(colliderCastInput, ref colliderCastHits);

                    for (var i = 0; i < colliderCastHits.Length; i++)
                    {
                        Debug.Log("fe");
                        var colliderCastHit = colliderCastHits[i];
                        Entity collisionEntity = physicsWorldSystem.PhysicsWorld.Bodies[colliderCastHit.RigidBodyIndex].Entity;
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