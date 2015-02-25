using UnityEngine;
using System.Collections;

namespace AngryChicken2D
{
	[DisallowMultipleComponent]
	public class RubberBandControl : MonoBehaviour
	{
		public Transform target;

		void LateUpdate()
		{
			Vector2 diff = transform.position - target.transform.position;

			transform.localRotation = Quaternion.FromToRotation(Vector3.right, diff);
			transform.localScale = new Vector3(diff.magnitude * 3.4f, transform.localScale.y);
		}
	}
}