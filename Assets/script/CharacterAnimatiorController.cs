using UnityEngine;

public class CharacterAnimatiorController : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D col)
	{
		GetComponent<Animator>().SetTrigger("Hit");
	}
}
