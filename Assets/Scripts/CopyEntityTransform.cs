using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class CopyEntityTransform : MonoBehaviour, IConvertGameObjectToEntity
{
	public Entity entity;
	public GameObject copyTo;
	[Space(10)] public bool dontCopyTranslation;
	public bool dontCopyRotation;
	public bool deathNotNeeded;
	public string deathAnimation;
	public float deathTime;

	private bool isDie;
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
		if(isDie) return;
		if (World.Active.EntityManager.Exists(entity))
		{
			if (!dontCopyTranslation)
				copyTo.transform.position = World.Active.EntityManager.GetComponentData<Translation>(entity).Value;
			if (!dontCopyRotation)
				copyTo.transform.rotation = World.Active.EntityManager.GetComponentData<Rotation>(entity).Value;
		}
		else
		{
			isDie = true;
			if (!deathNotNeeded)
			{
				GetComponent<Animation>().Play(deathAnimation);
				Invoke(nameof(Destroy), deathTime);
			}
			else
			{
				Destroy();
			}
		}
	}

	private void Destroy()
	{
		Destroy(copyTo);
		Destroy(gameObject);
	}
}