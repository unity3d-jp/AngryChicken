using UnityEngine;
using System.Collections;

public class BackgroundRender : MonoBehaviour
{
	public RenderTexture texture{ get; private set; }

	void Awake()
	{
		texture = new RenderTexture(Screen.width, Screen.height, 24);
		camera.targetTexture = texture;
	}

	void OnPostRender()
	{
		gameObject.SetActive(false);
	}
}