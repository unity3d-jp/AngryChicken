using UnityEngine;
using System.Collections;


namespace AngryChicken2D
{
	public class TargetCount : MonoBehaviour
	{
		public int count;
		GameObject[] objects;

		public float interval = 3;

		float nextTime;

		void Update()
		{
			if (Time.time > nextTime)
			{
				objects = GameObject.FindGameObjectsWithTag("Target");
				count = objects.Length;
				nextTime += interval;
			}
		}
	}
}