using UnityEngine;
using System.Collections;

namespace AngryChicken2D
{

	public class LookatSprite : MonoBehaviour
	{
		public Transform target;

		void Update()
		{
			Vector2 diff = transform.position - target.position;
			transform.rotation = Quaternion.FromToRotation( Vector3.up, diff.normalized );
		}
	}

}
