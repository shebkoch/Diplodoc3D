using ECS.Component;
using ECS.Component.Artifacts.Util;
using ECS.Component.Flags;
using ECS.System.Attack;
using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace ECS.System.Artifacts.Util
{
	[UpdateBefore(typeof(DamageReceivedSystem))]
	[UpdateAfter(typeof(MeleeAttackSystem))]
	public class ChanceByHpLoseSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			Random random = Rand.GetRandom();
			int lastReceived = 0;

			Entities.ForEach((Entity e,
				ref PlayerTag playerTag,
				ref DamageReceivedComponent damageReceivedComponent) =>
			{
				lastReceived = damageReceivedComponent.damage;				
			});
			Entities.ForEach((Entity e,
				ref ChanceByHpLoseComponent chanceByHpLoseComponent,
				ref ChanceArtifactComponent chanceArtifactComponent) =>
			{
				
				int chance = chanceArtifactComponent.chance;
				bool isActivate = false;
				for (int i = 0; i < lastReceived; i++)
				{
					int randInt = random.NextInt(100);
					isActivate = randInt < chance;
					if(isActivate) break;
				}

				chanceByHpLoseComponent.isActivate = isActivate;
			});
		}		
	}
}