using UnityEngine;

namespace AngryChicken2D
{
	[RequireComponent(typeof(TraceCatchObject))]
	public class SlingShot : MonoBehaviour
	{
		/// <summary>
		/// 発射時の強度
		/// </summary>
		[Range(0, 500)]
		public int
			power;

		/// <summary>
		/// 引ける最大値
		/// </summary>
		[Range(0, 5)]
		public float
			maxPower = 3;

		/// <summary>
		///発射するために必要な最小値
		/// </summary>
		[Range(0, 3)]
		public float
			minPower = 1;

		/// <summary>
		/// 掴んでいるオブジェクト
		/// </summary>
		[HideInInspector]
		public GameObject
			catchObject;

		void Update()
		{
			TouchControl();
		}

		void TouchControl()
		{
			Vector2 slingShotPos = transform.position;

			// put
			if (Input.GetMouseButtonDown(0))
			{
				Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10);
				Collider2D col = Physics2D.OverlapCircle(pos, 1);
				
				if (col != null && col.CompareTag("Player") && col.GetComponent<Rigidbody2D>().isKinematic)
				{
					catchObject = col.gameObject;
					GetComponent<TraceCatchObject>().enabled = true;
				}
			}

			// move
			if (catchObject != null && Input.GetMouseButton(0))
			{
				Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10);
				Vector2 diff = pos - slingShotPos;
				catchObject.transform.position = Vector2.ClampMagnitude(diff, maxPower) + slingShotPos;
			}

			// release
			if (catchObject != null && Input.GetMouseButtonUp(0))
			{
				Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10);
				Vector2 diff = slingShotPos - pos;
				
				if (diff.magnitude > minPower)
				{
					catchObject.GetComponent<Rigidbody2D>().isKinematic = false;
					catchObject.GetComponent<Rigidbody2D>().AddForce(diff * power);
				}
				
				GetComponent<TraceCatchObject>().enabled = false;
				catchObject = null;
			}
		}

		/// <summary>
		/// デバッグ用のドラッグ範囲表示
		/// </summary>
		void OnDrawGizmosSelected()
		{
			//引ける最大値
			Gizmos.color = Color.white;
			Gizmos.DrawWireSphere(transform.position, maxPower);
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, minPower);
			Gizmos.color = Color.white;
		}
	}
}