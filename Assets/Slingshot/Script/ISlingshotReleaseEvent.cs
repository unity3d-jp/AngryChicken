using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace AngryChicken2D
{
	public interface ISlingshotReleaseEvent : IEventSystemHandler 
	{
		void OnReleasePlayer(GameObject player);
	}
	public interface ISlingshotDragEvent : IEventSystemHandler 
	{
		void OnDragPlayer(GameObject player);
	}
}