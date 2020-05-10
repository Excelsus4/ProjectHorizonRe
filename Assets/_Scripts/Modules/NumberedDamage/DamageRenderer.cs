using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.Modules.NumberedDamage {
	public class DamageRenderer : MonoBehaviour {
		public float m_RiseSpeed;
		public float m_TimeToLive;

		private DamageSkin m_CurrentSprite;
		public SpriteRenderer[] m_SpriteRenderers;
		public SpriteRenderer m_CriticalEffect;
		public Transform m_NumberHolder;

		private float m_shift = 0;
		private bool m_isLoose;

		private void Awake() {
			m_isLoose = false;
			m_CriticalEffect.enabled = false;
		}

		private void Start() {
		}

		// Update is called once per frame
		void Update() {
			if (m_isLoose) {
				transform.Translate(Time.deltaTime * m_RiseSpeed * 0.2f, Time.deltaTime * m_RiseSpeed, 0);
				m_TimeToLive -= Time.deltaTime;
				if (m_TimeToLive < 0)
					Destroy(gameObject);
			}
		}

		public void SetDamageText(int Text) {
			int damage = Text;
			int temp;
			for (int idi = 0; idi < m_SpriteRenderers.Length; idi++) {
				temp = damage % (int)Mathf.Pow(10, idi + 1);
				temp /= (int)Mathf.Pow(10, idi);
				m_SpriteRenderers[idi].sprite = m_CurrentSprite.fromZeroToNine[temp];
				m_SpriteRenderers[idi].enabled = true;
				damage -= temp;
			}
			for (int idi = m_SpriteRenderers.Length - 1; idi >= 0; idi--) {
				if (m_SpriteRenderers[idi].sprite == m_CurrentSprite.fromZeroToNine[0]) {
					m_SpriteRenderers[idi].enabled = false;
					m_CriticalEffect.transform.localPosition = new Vector3(1.1f - idi * 0.3f, 0.1f, -0.02f);
				} else {
					transform.Translate(-m_shift, 0, 0);
					m_shift = ( idi - 7 ) * 0.15f;
					transform.Translate(m_shift, 0, 0);
					break;
				}
			}
			//m_TextRenderer.text = Text;
		}

		public void SetDamageSkin(DamageSkin damageSkin) {
			m_CurrentSprite = damageSkin;
		}

		public void SetLoose() {
			m_isLoose = true;
		}
	}
}