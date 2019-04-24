using ECS.Component.Creatures;
using ECS.Component.Flags;
using ECS.Component.Relations;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS.System.Relations
{
	public class PlayerFollowSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			float3 position = new float3();
			Entities.ForEach((Entity e,
				ref PlayerTag playerTag,
				ref Translation translation) =>
			{
				position = translation.Value;
			});
			Entities.ForEach((Entity e,
				ref PlayerFollowComponent playerFollowComponent,
				ref Translation translation,
				ref MovingComponent movingComponent) =>
			{
				float3 enemyPosition = translation.Value;
				float offset = playerFollowComponent.offset;
				bool offsetEnable = playerFollowComponent.offsetEnable;
				
				float horizontal = 0;
				float vertical = 0;
				float distance = math.distance(position.xz, enemyPosition.xz);
				if (!offsetEnable || distance > offset)
				{
					float2 result = math.normalize(position.xz - enemyPosition.xz);
					horizontal = result.x;
					vertical = result.y;
				}

				playerFollowComponent.distanceToPlayer = distance;
				movingComponent.vertical = vertical;
				movingComponent.horizontal = horizontal;
			
				
			});
			
		}
	}
}