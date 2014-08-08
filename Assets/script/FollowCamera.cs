using UnityEngine;
using System.Collections;
using System;

namespace AngryChicken2D
{
	public class FollowCamera : MonoBehaviour
	{
		public Transform  target;
		public Vector3 defaultDiff;

		[SerializeField]
		Rect stageRect;

		[SerializeField]
		Rect cameraRect;
		
		private Vector3 targetPos;
		private float height;
		
		private SpawnPlayer spawnner;
	
		[ContextMenu("set camera range")]
		void SetCameraRange()
		{
			var lt = camera.ViewportToWorldPoint(new Vector3(0, 1, target.position.z)) - transform.position;
			var rd = camera.ViewportToWorldPoint(new Vector3(1, 0, target.position.z)) - transform.position;
		
			defaultDiff = transform.position - target.position;
		
			cameraRect = new Rect(lt.x, rd.y, rd.x - lt.x, lt.y - rd.y);
		}
	
		void Start()
		{
			stageRect.x -= cameraRect.x;
			stageRect.width -= cameraRect.width;
		
			targetPos = transform.position;
			height = targetPos.y;
			
			
			spawnner =  Array.Find<GameObject>( GameObject.FindGameObjectsWithTag("Respawn") , (obj) => obj.GetComponent<SpawnPlayer>()).GetComponent<SpawnPlayer>();
		}
	
		void OnEnable()
		{
			if (target == null)
			{
				return;
			}
		}
	
		void LateUpdate()
		{
			if (target == null)
			{
				enabled = false;
			}

			
		
		
			var pos = target.position + defaultDiff;

			if (stageRect.Contains(pos))
			{
				targetPos = pos;
			}
		
			targetPos.y = height;
		
			transform.position = Vector3.Lerp(transform.position, targetPos, 0.02f);
		}
	
		void OnDrawGizmosSelected()
		{
			GizmoRect(stageRect);
		
		
			var cr = cameraRect;
			cr.x += transform.position.x;
			cr.y += transform.position.y;
		
			GizmoRect(cr);
		
		}
	
		void GizmoRect(Rect rect)
		{
			var lt = new Vector3(rect.x, rect.y, target.position.z);
			var rt = new Vector3(rect.x + rect.width, rect.y, target.position.z);
			var ld = new Vector3(rect.x, rect.y + rect.height, target.position.z);
			var rd = new Vector3(rect.x + rect.width, rect.y + rect.height, target.position.z);
		
			Gizmos.DrawLine(lt, rt);
			Gizmos.DrawLine(lt, ld);
			Gizmos.DrawLine(rt, rd);
			Gizmos.DrawLine(rd, ld);
		}
	}
}