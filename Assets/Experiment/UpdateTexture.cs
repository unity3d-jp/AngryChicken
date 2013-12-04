using UnityEngine;
using System.Collections;

namespace AngryChicken2D
{

	public class UpdateTexture : MonoBehaviour
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

}