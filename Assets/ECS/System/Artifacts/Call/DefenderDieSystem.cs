using ECS.Component;
using ECS.Component.Artifacts.Call;
using ECS.Component.Damage;
using Unity.Entities;

namespace ECS.System.Artifacts.Call
{
[DisableAutoCreation]	public class DefenderDieSystem : ComponentSystem
	{
		protected struct Defender
		{
			
		}

		protected override void OnUpdate()
		{
			Entities.ForEach((Entity e,
				ref PlayerDefenderComponent playerDefenderComponent,
				ref DurationComponent durationComponent,
				ref DeathComponent deathComponent) =>
			{
				if (durationComponent.isEnd)
					deathComponent.isDeathNeed = true;
			});
		}
	}
}