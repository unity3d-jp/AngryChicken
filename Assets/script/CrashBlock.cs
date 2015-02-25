using UnityEngine;

[DisallowMultipleComponent]
public class CrashBlock : MonoBehaviour
{
	public float strength, hp;
	public GameObject effect;

	void OnCollisionEnter2D(Collision2D col)
	{
		float damage = col.relativeVelocity.magnitude - strength;
		if (damage > 0)
		{
			hp -= damage;
		}

		if (hp < 0)
		{
			Destroy(gameObject);
			GameObject.Instantiate(
					effect, 
					transform.position, 
					Quaternion.identity);
		}
	}
}