using UnityEngine;
using System.Collections;

public class SwitchScene : MonoBehaviour
{
	public string[] sceneList;

	void OnGUI()
	{
		foreach (string sceneName in sceneList)
		{
			if (GUILayout.Button(sceneName))
			{
				Application.LoadLevel(sceneName);
			}
		}
	}
}
