using ECS.Component.Attack;
using ECS.Component.Creatures;
using Structures;
using Unity.Entities;
using UnityEngine;

namespace ECS.System.Attack
{
[DisableAutoCreation]    public class MeleeAttackSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Entity e,
                ref MeleeAttackComponent meleeAttackComponent,
                ref MeleeWeaponComponent meleeWeaponComponent,
                ref AnimatorComponent animator) =>
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

//                if (enabled)
//                    meleeAttackComponent.weaponCollider.gameObject.GetComponent<CollisionComponent>().damage =
//                        weapon.damage;
                meleeWeaponComponent.meleeWeapon = weapon;
                meleeAttackComponent.weaponCollider.enabled = enabled;
                animator.isAnimationNeeded = isAnimationNeeded;
            });
        }
    }
}