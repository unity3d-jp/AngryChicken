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
			float angle = Vector2.Angle(Vector2.right, diff.normalized);
		
			angle = (diff.y < 0) ? angle = 360 - angle : angle;
			transform.localEulerAngles = new Vector3(0, 0, angle);
		}
	}

}
