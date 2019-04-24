using ECS.Component.Artifacts.Util;
using ECS.Component.Stats;
using ECS.System.Stats;
using Unity.Entities;
using Random = Unity.Mathematics.Random;

namespace ECS.System.Artifacts.Util
{
	[UpdateAfter(typeof(PlayerParametersStatSystem))]
[DisableAutoCreation]	public class ChanceByHpLoseSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			Random random = Rand.GetRandom();
			int lastReceived = 0;

			Entities.ForEach((Entity e,
				ref PlayerParametersStatComponent playerParametersStatComponent) =>
			{
				lastReceived = playerParametersStatComponent.lastReceived;				
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