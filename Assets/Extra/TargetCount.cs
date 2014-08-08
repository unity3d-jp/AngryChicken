using UnityEngine;
using System.Collections;

namespace AngryChicken2D
{
	public class TargetCount : MonoBehaviour
	{
		public int count{ get; private set; }
		public float interval = 3;

		float nextTime;

		void Start()
		{
			count = 1;
		}

		void Update()
		{
			if (Time.time > nextTime)
			{
				var t = GameObject.Find("Target");
				if (t == null)
				{
					count = 0;
				} else
				{
					count = 1;
				}
				//count = GameObject.FindGameObjectsWithTag("Target").Length;
				nextTime += interval;
			}

			if (count == 0)
			{
				Debug.Log("clear");
			}
		}
	}
}