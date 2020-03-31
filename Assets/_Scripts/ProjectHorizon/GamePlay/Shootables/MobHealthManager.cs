using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.ProjectHorizon.GamePlay.Miscellaneous;

namespace com.meiguofandian.ProjectHorizon.GamePlay.Shootables {
	public class MobHealthManager : MonoBehaviour {
		public UnityEngine.UI.Slider m_HealthBar;
		public int m_MaxHealth;
		public int m_Armor;
		public int m_CritResistance;
		public GameObject m_DamagePrefab;
		private IMobAnimation m_AnimationManager;

		//드랍테이블
		public CharacterData.ResourceType m_DropResource;
		public int m_DropAmount;

		private DamageRenderer m_damageRenderer;
		private int m_damageSum;

		private int m_currentHealth;
		private float m_fastHit;

		private int m_multipleDamage;
		private int m_multipleTimes;

		// Use this for initialization
		void Start() {
			m_currentHealth = m_MaxHealth;
			m_AnimationManager = GetComponent<IMobAnimation>();
		}

		private void Update() {
			if (m_multipleTimes > 0) {
				DealDamage(m_multipleDamage * (int)Mathf.Pow((float)m_multipleTimes, 2), DamageRenderer.DamageType.Normal);
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

		public void DealDamage(float damage, DamageRenderer.DamageType damageType) {
			if (m_damageRenderer == null) {
				m_damageRenderer = Instantiate(m_DamagePrefab, transform.position + new Vector3(0, 1.6f), Quaternion.Euler(0, 0, 0)).GetComponent<DamageRenderer>();
				m_fastHit = 0;
			}

			float fakeDamage = damage;
			switch (damageType) {
			case DamageRenderer.DamageType.Critical:
				m_damageRenderer.SetCritical();
				fakeDamage *= 100 / ( 100 + m_CritResistance );
				fakeDamage *= 100 / ( 100 + m_Armor );
				break;
			case DamageRenderer.DamageType.Normal:
				fakeDamage *= 100 / ( 100 + m_Armor );
				break;
			case DamageRenderer.DamageType.Penetration:
				m_damageRenderer.SetPenetration();
				break;
			}
			int realDamage = Mathf.CeilToInt(Random.Range(damage * 0.9f, damage));

			m_currentHealth -= realDamage;

			m_damageSum += realDamage;
			m_damageRenderer.SetDamageText(m_damageSum);
			m_AnimationManager.Attacked();

			if (m_currentHealth <= 0) {
				m_currentHealth = 0;
				Death();
			}
			m_HealthBar.value = (float)m_currentHealth / (float)m_MaxHealth;
			m_fastHit = 0;

			m_AnimationManager.Attacked();
		}

		public void DealMultipleDamage(int damage) {
			if (damage == m_multipleDamage)
				m_multipleTimes++;
			else {
				DealDamage(m_multipleDamage * (int)Mathf.Pow((float)m_multipleTimes, 2), DamageRenderer.DamageType.Normal);
				m_multipleDamage = damage;
				m_multipleTimes = 1;
			}
		}

		private void Death() {
			if (m_damageRenderer != null) {
				m_damageRenderer.SetLoose();
			}

			//BlobManager blob = Instantiate(GlobalDatabase.m_BlobTable[(int)m_DropResource], transform.position, Quaternion.identity).GetComponent<BlobManager>();
			//blob.Target = com.meiguofandian.ProjectHorizon.GamePlay.Shooting.VoxelInputControl.CharacterLocation;
			//blob.ResourceAmount = m_DropAmount;

			m_AnimationManager.Death();

			Destroy(gameObject, 2);
		}
	}
}