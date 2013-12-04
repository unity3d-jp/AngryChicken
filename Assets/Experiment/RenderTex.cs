using UnityEngine;
using System.Collections;

public class RenderTex : MonoBehaviour
{
	[SerializeField]
	BackgroundRender
		back;

	void Start()
	{
		renderer.enabled = true;
		renderer.material.mainTexture = back.texture;
	}
}
