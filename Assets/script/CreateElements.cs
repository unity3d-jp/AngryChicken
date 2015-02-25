using UnityEngine;
using System.Collections;

namespace AngryChidlen2D
{
	[DisallowMultipleComponent]
	public class CreateElements : MonoBehaviour 
	{
		[SerializeField]
		RectTransform baseElement;

		[SerializeField, Range(1, 30)]
		int elementCount = 10;

		void Start()
		{
			for(int i=0; i<elementCount; i++)
			{
				var element = (RectTransform)GameObject.Instantiate(baseElement);
				element.gameObject.name = "Element" + (i + 1);
				element.SetParent(transform, false);
			}

			baseElement.gameObject.SetActive(false);
		}

	}
}