using Unity.Entities;
using UnityEngine;

namespace ECS.Component.Artifacts.Call
{
	public class CallArtifactComponentProxy : MonoBehaviour, IConvertGameObjectToEntity
	{
		public GameObject calling;
		public int count;
		

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var data = new CallArtifactComponent
			{
				calling = conversionSystem.GetPrimaryEntity(calling),
				count = count,

			};
			dstManager.AddSharedComponentData(entity, data);
		}
	}
}