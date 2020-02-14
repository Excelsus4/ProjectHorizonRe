using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRenderer : MonoBehaviour {
	public enum DamageType
	{
		Normal,
		Critical,
		Penetration
	}

	public float m_RiseSpeed;
	public float m_TimeToLive;

	private Sprite[] m_CurrentSprite;

	public Sprite[] m_DamageSprite;
	public Sprite[] m_CriticalSprite;
	public SpriteRenderer[] m_SpriteRenderers;
	public SpriteRenderer m_CriticalEffect;
	public Transform m_NumberHolder;

	private float m_shift=0;
	private bool m_isLoose;
	private DamageType m_isCritical;

	private void Awake()
	{
		m_isLoose = false;
		m_isCritical = DamageType.Normal;
		m_CurrentSprite = m_DamageSprite;
		m_CriticalEffect.enabled = false;

	}

	private void Start()
	{
	}

	// Update is called once per frame
	void Update () {
		if (m_isLoose)
		{
			transform.Translate(Time.deltaTime * m_RiseSpeed * 0.2f, Time.deltaTime * m_RiseSpeed, 0);
			m_TimeToLive -= Time.deltaTime;
			if (m_TimeToLive < 0)
				Destroy(gameObject);
		}
	}

	public void SetDamageText(int Text)
	{
		int damage = Text;
		int temp;
		for(int idi = 0; idi < m_SpriteRenderers.Length; idi++)
		{
			temp = damage % (int)Mathf.Pow(10, idi+1);
			temp /= (int)Mathf.Pow(10, idi);
			m_SpriteRenderers[idi].sprite = m_CurrentSprite[temp];
			m_SpriteRenderers[idi].enabled = true;
			damage -= temp;
		}
		for(int idi = m_SpriteRenderers.Length - 1; idi >= 0; idi--)
		{
			if (m_SpriteRenderers[idi].sprite == m_CurrentSprite[0])
			{
				m_SpriteRenderers[idi].enabled = false;
				m_CriticalEffect.transform.localPosition = new Vector3(1.1f - idi * 0.3f, 0.1f, -0.02f);
			}
			else
			{
				transform.Translate(-m_shift, 0, 0);
				m_shift = (idi - 7) * 0.15f;
				transform.Translate(m_shift, 0, 0);
				break;
			}
		}
		//m_TextRenderer.text = Text;
	}

	public void SetLoose()
	{
		m_isLoose = true;
	}

	public void SetCritical()
	{
		m_isCritical = DamageType.Critical;
		m_CurrentSprite = m_CriticalSprite;
		m_CriticalEffect.enabled = true;
		m_NumberHolder.localScale = new Vector3(2f, 2f, 2f);
	}

	public void SetPenetration()
	{
		m_isCritical = DamageType.Penetration;
	}
}
