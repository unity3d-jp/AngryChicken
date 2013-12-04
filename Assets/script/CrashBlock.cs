using UnityEngine;

public class CrashBlock : MonoBehaviour
{
	public float m_Strength, m_hp;
	public GameObject m_Effect;

	void OnCollisionEnter2D(Collision2D col)
	{
		float damage = col.relativeVelocity.magnitude - m_Strength;
		if (damage > 0)
		{
			m_hp -= damage;
		}

		if (m_hp < 0)
		{
			Destroy(gameObject);
			GameObject.Instantiate(
					m_Effect, 
					transform.position, 
					Quaternion.identity);
		}
	}
}