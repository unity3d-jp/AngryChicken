using UnityEngine;
using System.Collections;

namespace AngryChicken2D.Experiment
{

	public class BackgroundRender : MonoBehaviour
	{
		public RenderTexture texture{ get; private set; }

		void Awake()
		{
			texture = new RenderTexture(Screen.width, Screen.height, 24);
			texture.enableRandomWrite = false;
			camera.targetTexture = texture;
		}

		void OnPostRender()
		{
			gameObject.SetActive(false);
		}
	}
}