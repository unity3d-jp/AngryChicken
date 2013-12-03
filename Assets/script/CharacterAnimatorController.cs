using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D col)
	{
		GetComponent<Animator>().SetTrigger("Hit");
	}
}
