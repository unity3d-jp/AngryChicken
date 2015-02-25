using UnityEngine;
using System.Collections;

namespace AngryChicken2D
{
	[DisallowMultipleComponent]
	public class LookatSprite : MonoBehaviour
	{
		public Transform target;

		void LateUpdate()
		{
			Vector2 diff = transform.position - target.position;
			transform.rotation = Quaternion.FromToRotation( Vector3.up, diff.normalized );
		}
	}

}
