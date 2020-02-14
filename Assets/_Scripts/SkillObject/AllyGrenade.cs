using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyGrenade : MonoBehaviour {
	public UnityEngine.UI.Slider m_TimeLeftSlider;
	public float m_TimeBeforeExplode;
	public int m_DamagePerRay;  //36 Rays in All directions

	private bool m_TickStart;

	private float m_timeLeft;

	// Use this for initialization
	void Start () {
		m_timeLeft = m_TimeBeforeExplode;
		m_TickStart = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (m_TickStart)
		{
			m_TimeLeftSlider.transform.eulerAngles = new Vector3(0, 0, 0);

			m_timeLeft -= Time.deltaTime;
			m_TimeLeftSlider.value = m_timeLeft / m_TimeBeforeExplode;
			if (m_timeLeft < 0)
			{
				for (int theta = 0; theta < 360; theta += 3)
				{
					RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(Mathf.Cos(theta), Mathf.Sin(theta)), 40f, LayerMask.GetMask("Mob", "Terrain"));
					if (hit.collider != null)
					{
						MobHealthManager mob = hit.collider.GetComponent<MobHealthManager>();
						if (mob != null)
							mob.DealMultipleDamage(m_DamagePerRay);
					}
				}

				Destroy(gameObject);
			}
		}
	}

	public void LooseHandle()
	{
		m_TickStart = true;
	}
}
