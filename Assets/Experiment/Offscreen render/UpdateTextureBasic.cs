using UnityEngine;
using System.Collections;

namespace AngryChicken2D
{

	public class UpdateTextureBasic : MonoBehaviour
	{

		public BackgroundRenderBasic target;

		// Use this for initialization
		void Start()
		{
			target.result = () =>
			{
				renderer.material.mainTexture = target.screenshot;
				renderer.enabled = true;
				target.result = null;
			};
		}
		void OnDestroy()
		{
			target.result = null;
		}

	}
}