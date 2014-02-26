using System.Collections;
using UnityEngine;

namespace AngryChicken2D
{
	public class SpawnPlayer : MonoBehaviour
	{
		public GameObject playerPrefab;
		bool canSpawn = false;
		SlingShot slingShot;
		GameObject catchObject;

		[Range(3, 30)]
		public int
			respawnTime = 5;

		void Start()
		{
			slingShot = GetComponent<SlingShot>();
			if (playerPrefab == null)
				enabled = false;
		}
	
		void Update()
		{
			if (canSpawn)
			{
				if (Input.GetKeyDown(KeyCode.Mouse0))
				{
					GameObject.Instantiate(playerPrefab, transform.position, Quaternion.identity);
					canSpawn = false;
				}


				if (Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") < 0)
				{
					GameObject.Instantiate(playerPrefab, transform.position, Quaternion.identity);
					canSpawn = false;
				}



			} else
			{
				if (catchObject == null)
				{
					catchObject = slingShot.catchObject;
				}

				if (catchObject != null && Vector2.Distance(catchObject.transform.position, transform.position) > slingShot.maxPower * 1.3f)
				{
					StartCoroutine(Shooting(catchObject));
					catchObject = null;
				}
			}
		}

		IEnumerator Shooting(GameObject obj)
		{
			DestroyObject(obj, 20);
			yield return new WaitForSeconds(respawnTime);
			canSpawn = true;
		}
	
		void OnGUI()
		{
			if (canSpawn)
				GUILayout.Label("push to next shoot");
		}
	}
}