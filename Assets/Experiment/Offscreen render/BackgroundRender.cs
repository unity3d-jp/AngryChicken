using UnityEngine;
using System.Collections;

namespace AngryChicken2D
{
	public class BackgroundRender : MonoBehaviour
	{
		[Range(1, 10)]
		public int
			scale = 1;

		public RenderTexture texture{ get; private set; }

		void Awake()
		{
			texture = new RenderTexture(Screen.width / scale, Screen.height / scale, 24);
			texture.enableRandomWrite = false;
			texture.antiAliasing = 4;
			camera.targetTexture = texture;

			DontDestroyOnLoad(gameObject);
		}

		void OnPostRender()
		{
			gameObject.SetActive(false);
		}
	}
}