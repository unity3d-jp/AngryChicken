using UnityEngine;
using System.Collections;
using System.IO;
using System;

namespace AngryChicken2D
{

	public class BackgroundRenderBasic : MonoBehaviour
	{
		public Texture2D screenshot { get; private set; }
		RenderTexture renderTexture = null;
		public Action result = null;

		[Range(1, 5)]
		public int
			textureScale = 1;
	
		void Awake()
		{
			int width = Screen.width / textureScale;
			int height = Screen.height / textureScale;
			screenshot = new Texture2D(width, height, TextureFormat.RGB24, false);
			renderTexture = new RenderTexture(width, height, 24);
			camera.targetTexture = renderTexture;
		}
	
		void OnPostRender()
		{
			Take();
		
			if (result != null)
				result();

			gameObject.SetActive(false);
		}
	
		protected void Take()
		{
			screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
			screenshot.Apply();
		}

		void OnDestroy()
		{
			Destroy(renderTexture);
			Destroy(screenshot);
			result = null;
		}
	}
}