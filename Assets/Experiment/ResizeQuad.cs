using UnityEngine;
using System.Collections;

public class ResizeQuad : MonoBehaviour
{
	public Camera targetCamera;
	void Start()
	{
		Vector3 v3 = transform.localScale;
		v3.y = targetCamera.orthographicSize * 2;
		v3.x = v3.y * targetCamera.aspect;
		transform.localScale = v3;
	}
}
