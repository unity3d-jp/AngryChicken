using UnityEngine;
using System.Collections;

namespace AngryChicken2D
{
	public class TargetCount : MonoBehaviour
	{
		public int count;
		public float interval = 3;

		float nextTime;

		void Update()
		{
			if (Time.time > nextTime)
			{
				count = GameObject.FindGameObjectsWithTag("Target").Length;
				nextTime += interval;
			}
		}
	}
}