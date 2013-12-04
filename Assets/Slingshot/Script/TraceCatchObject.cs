using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SlingShot))]
public class TraceCatchObject : MonoBehaviour
{
	public GameObject pick;
	private SlingShot slingshot;

	void Start()
	{
		slingshot = GetComponent<SlingShot>();
		enabled = false;
	}

	void Update()
	{
		GameObject target = slingshot.catchObject;
		Vector2 diff = target.transform.position - transform.position;
		pick.transform.position = (Vector2)target.transform.position + diff.normalized * 0.2f;
	}
}
