using ECS.Component.Modificators;
using Unity.Entities;

namespace ECS.System.Modifiers
{
	//TODO
[DisableAutoCreation]	public class StunModificatorDrawing : ComponentSystem
	{

		protected override void OnUpdate()
		{
			Entities.ForEach((Entity e,
				ref StunModificatorComponent stunModificatorComponent) =>
			{
//				stunModificatorComponent.indicator.fillAmount = stunModificatorComponent.fillAmount;
			});
		}
	}
}