using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace AngryChicken2D
{
	[DisallowMultipleComponent]
	public class SlingShot : MonoBehaviour
	{
		/// <summary>
		/// 発射時の強度
		/// </summary>
		[SerializeField, Range(0, 500)]
		public int power;

		/// <summary>
		/// 引ける最大値
		/// </summary>
		[SerializeField, Range(0, 5)]
		public float maxPower = 3;

		/// <summary>
		///発射するために必要な最小値
		/// </summary>
		[SerializeField, Range(0, 3)]
		private float minPower = 1;

		/// <summary>
		/// 掴んでいるオブジェクト
		/// </summary>
		[HideInInspector]
		public GameObject catchedPlayer;

		void Update()
		{
			if( catchedPlayer == null )
			{
				if (Input.GetMouseButtonDown(0))
				{
					catchedPlayer = CatchPlayer();
				}
				
			}else{
				
				if (Input.GetMouseButton(0))
				{
					DragPlayer(catchedPlayer);
				}
				
				if (Input.GetMouseButtonUp(0))
				{
					ReleasePlayer(catchedPlayer);
					catchedPlayer = null;
				}
			}
		}

		/// <summary>
		/// Catchs the player.
		/// </summary>
		/// <returns>The player.</returns>
		private GameObject CatchPlayer()
		{
			Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 100);
			Collider2D hitCollider = Physics2D.OverlapCircle(pos, 1);
			
			if (hitCollider != null && hitCollider.CompareTag("Player") && hitCollider.GetComponent<Rigidbody2D>().isKinematic)
			{
				GetComponent<TraceCatchObject>().enabled = true;
				return hitCollider.gameObject;
			}
			return null;
		}

		/// <summary>
		/// Drags the player.
		/// </summary>
		/// <param name="player">Player.</param>
		private void DragPlayer(GameObject player)
		{
			Vector2 slingShotPos = transform.position;

			Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 100);
			Vector2 diff = pos - slingShotPos;
			player.transform.position = Vector2.ClampMagnitude(diff, maxPower) + slingShotPos;

			ExecuteEvents.Execute<ISlingshotDragEvent>(gameObject, null, (obj, data)=>obj.OnDragPlayer( player ));
		}

		/// <summary>
		/// Releases the player.
		/// </summary>
		/// <param name="player">Player.</param>
		private void ReleasePlayer(GameObject player)
		{
			Vector2 slingShotPos = transform.position;

			Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 100);
			Vector2 diff = slingShotPos - pos;
			
			if (diff.magnitude > minPower)
			{
				player.GetComponent<Rigidbody2D>().isKinematic = false;
				player.GetComponent<Rigidbody2D>().AddForce(diff * power);

				GetComponent<TraceCatchObject>().enabled = false;

				ExecuteEvents.Execute<ISlingshotReleaseEvent>(gameObject, null, (item, data)=>item.OnReleasePlayer(player) );
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