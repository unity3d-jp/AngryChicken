using UnityEngine;
using System.Collections;

public class DestroyGameObject : MonoBehaviour
{
	public float time = 1.5f;

	void Start()
	{
		DestroyObject(gameObject, time);
	}
}