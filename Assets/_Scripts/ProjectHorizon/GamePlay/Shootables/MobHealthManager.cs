using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.Modules.NumberedDamage;

namespace com.meiguofandian.ProjectHorizon.GamePlay.Shootables {
	public class MobHealthManager : MonoBehaviour {
		public UnityEngine.UI.Slider m_HealthBar;

		public Numerics.MobDefensiveStat Stat;
		
		public GameObject m_DamagePrefab;
		private IMobAnimation m_AnimationManager;

		private DamageRenderer m_damageRenderer;
		private int m_damageSum;

		private int m_currentHealth;
		private float m_fastHit;

		private int m_multipleDamage;
		private int m_multipleTimes;

		// Use this for initialization
		void Start() {
			m_currentHealth = Stat.Health;
			m_AnimationManager = GetComponent<IMobAnimation>();
		}

		private void Update() {
			if (m_multipleTimes > 0) {
				DealDamage(m_multipleDamage * (int)Mathf.Pow((float)m_multipleTimes, 2), null);
				m_multipleDamage = 0;
				m_multipleTimes = 0;
			}

			if (m_damageRenderer != null) {
				m_fastHit += Time.deltaTime;
				if (m_fastHit > 0.0f) {
					m_damageRenderer.SetLoose();
					m_damageRenderer = null;
					m_damageSum = 0;
				}
			}
		}

		public void DealDamage(float damage, DamageSkin damageSkin) {
			if (m_damageRenderer == null) {
				m_damageRenderer = Instantiate(m_DamagePrefab, transform.position + new Vector3(0, 1.6f), Quaternion.Euler(0, 0, 0)).GetComponent<DamageRenderer>();
				m_fastHit = 0;
			}
			
			if(damageSkin!=null)
				m_damageRenderer.SetDamageSkin(damageSkin);
			int realDamage = Mathf.CeilToInt(Random.Range(damage * 0.9f, damage));

			m_currentHealth -= realDamage;

			m_damageSum += realDamage;
			m_damageRenderer.SetDamageText(m_damageSum);
			m_AnimationManager.Attacked();

			if (m_currentHealth <= 0) {
				m_currentHealth = 0;
				Death();
			}
			m_HealthBar.value = (float)m_currentHealth / (float)Stat.Health;
			m_fastHit = 0;

			m_AnimationManager.Attacked();
		}

		public void DealMultipleDamage(int damage) {
			if (damage == m_multipleDamage)
				m_multipleTimes++;
			else {
				DealDamage(m_multipleDamage * (int)Mathf.Pow((float)m_multipleTimes, 2), null);
				m_multipleDamage = damage;
				m_multipleTimes = 1;
			}
		}

		private void Death() {
			MobAttack attacker = GetComponentInParent<MobAttack>();
			if(attacker != null)
				attacker.enabled = false;
			GetComponent<MobHealthManager>().enabled = false;
			GetComponent<Collider2D>().enabled = false;
			if (m_damageRenderer != null) {
				m_damageRenderer.SetLoose();
			}

			LPlatformer.MapLiner a = GameObject.Find("MapLiner").GetComponent<LPlatformer.MapLiner>();
			foreach (string b in Stat.Tags)
				a.KillCount(b);

			m_AnimationManager.Death();

			Destroy(gameObject, 2);
		}
	}
}