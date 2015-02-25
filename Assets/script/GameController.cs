using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class GameController : MonoBehaviour 
{
	[System.Serializable]
	public class OnGameClear : UnityEngine.Events.UnityEvent{}

	public OnGameClear onGameClear = null;

	void Update()
	{
		if( GameObject.FindGameObjectsWithTag("Target").Length == 0 )
		{
			Clear();
			enabled = false;
		}
	}

	void Clear()
	{
		onGameClear.Invoke();
		Debug.Log("YOU WIN");
	}
}
