using UnityEngine;
using System.Collections;

public class RubberBandControl : MonoBehaviour
{
	public Transform target;

	void FixedUpdate()
	{
		Vector2 diff = transform.position - target.transform.position;
		float angle = Vector2.Angle(Vector2.right, diff.normalized);
		
		angle = (diff.y < 0) ? angle = 360 - angle : angle;
		transform.localEulerAngles = new Vector3(0, 0, angle);
		transform.localScale = new Vector3(diff.magnitude * 3.2f, transform.localScale.y);
	}
}