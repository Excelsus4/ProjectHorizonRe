using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.Modules.NumberedDamage;

namespace com.meiguofandian.ProjectHorizon.GamePlay.PlayerDamager {
	public class PlayerCharacterDamager : MonoBehaviour {
		public UnityEngine.UI.Slider m_HealthBar;
		public PlayerBindStat stat;
		public GameObject m_DamagePrefab;
		private int currentHP;
		private float immunity;

		private void Awake() {
			stat = PlayerStatData.getSingleton().playerData;
			currentHP = stat.maxHP;
			m_HealthBar.maxValue = stat.maxHP;
			m_HealthBar.minValue = 0;
			m_HealthBar.value = currentHP;
		}

		private void FixedUpdate() {
			if (immunity > 0f)
				immunity -= Time.deltaTime;
		}

		public void TryDamage(int Damage, DamageSkin damageSkin) {
			if(immunity <= 0f) {
				DamageRenderer damageBalloon = Instantiate(m_DamagePrefab, transform.position + new Vector3(0, 1.6f), Quaternion.Euler(0, 0, 0)).GetComponent<DamageRenderer>();
				damageBalloon.SetDamageSkin(damageSkin);
				damageBalloon.SetDamageText(Damage);
				damageBalloon.SetLoose();
				immunity = stat.immuneTime;

				currentHP -= Damage;
				m_HealthBar.value = currentHP;
			}
		}
	}
}