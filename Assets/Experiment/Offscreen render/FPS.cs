using UnityEngine;
using System.Collections;

public class FPS : MonoBehaviour
{
	[SerializeField]
	[Range(15, 120)]
	int
		framerate = 60;
	void Start()
	{
		Application.targetFrameRate = framerate;
	}
}
