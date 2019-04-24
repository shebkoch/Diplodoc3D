using ECS.System.Artifacts;
using Unity.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKey(KeyCode.R))
		{
			SceneManager.LoadScene(0);
			World.Active.GetExistingSystem<StartArtifactDistributionSystem>().Enabled = true;
			World.Active.GetExistingSystem<LuckArtifactSystem>().Enabled = true;
		}
			
	}
}