using UnityEngine;
using System.Collections;

namespace AngryChicken2D
{
	[RequireComponent(typeof(SlingShot)), DisallowMultipleComponent]
	public class TraceCatchObject : MonoBehaviour, ISlingshotDragEvent
	{
		public GameObject pick;

		public void OnDragPlayer(GameObject target)
		{
			Vector2 diff = target.transform.position - transform.position;
			pick.transform.position = (Vector2)target.transform.position + diff.normalized * 0.2f;
		}
	}
}
