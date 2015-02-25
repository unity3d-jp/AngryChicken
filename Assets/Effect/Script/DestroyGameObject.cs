using UnityEngine;
using System.Collections;

namespace Effect
{
	public class DestroyGameObject : MonoBehaviour
	{
		public float time = 1.5f;
		
		void Start()
		{
			DestroyObject(gameObject, time);
		}
	}
}