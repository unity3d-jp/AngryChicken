using UnityEngine;
using System.Collections;

public class ClearCheck : MonoBehaviour
{


	void Update()
	{
		GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
	

		if (targets.Length == 0)
		{
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}