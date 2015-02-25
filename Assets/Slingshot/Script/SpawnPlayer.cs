using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AngryChicken2D
{
	[RequireComponent(typeof(SlingShot)), DisallowMultipleComponent]
	public class SpawnPlayer : MonoBehaviour, ISlingshotReleaseEvent
	{
		GameObject currentPlayer;

		[SerializeField]
		GameObject playerBaseInstance;

		void Awake()
		{
			if( playerBaseInstance == null ){
				return;
			}

			playerBaseInstance.SetActive(false);
		}

		void Start()
		{
			CreatePlayer();
		}

		public void CreateNewPlayer(Button button)
		{
			if( currentPlayer != null || playerBaseInstance == null)
				return;
			
			button.gameObject.SetActive(false);

			CreatePlayer();
		}

		void CreatePlayer()
		{
			if( playerBaseInstance == null )
				return;

			currentPlayer = (GameObject) GameObject.Instantiate(
				playerBaseInstance, 
				transform.position, 
				Quaternion.identity);
			
			currentPlayer.SetActive(true);
		}

		public void OnReleasePlayer(GameObject player)
		{
			currentPlayer = null;
		}
	}
}