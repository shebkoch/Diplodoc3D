using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class CopyEntityTransform : MonoBehaviour, IConvertGameObjectToEntity
{
	public Entity entity;
	public GameObject copyTo;

	private void Start()
	{
		if (copyTo == null) copyTo = gameObject;
	}

	public void Convert(Entity convertEntity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
	{
		entity = convertEntity;
	}

	private void Update()
	{
		copyTo.transform.position = World.Active.EntityManager.GetComponentData<Translation>(entity).Value;
		copyTo.transform.rotation = World.Active.EntityManager.GetComponentData<Rotation>(entity).Value;
	}
}