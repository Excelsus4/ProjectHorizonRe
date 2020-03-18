using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	[Serializable]
	public class Statistics {
		// Offensive
		public int damage;
		public int damageCap;
		public int attackSpeed;
		public int penetration;

		public float recoil;
		public float recoilRecovery;
		public float accuracy;
		public float spread;
		public int rounds;
		public float reloadSpeed;

		public float criticalChance;
		public float criticalDamage;

		public Statistics() {
			Reset();
		}

		// Methods
		public void Reset() {
			damage = 0;
			damageCap = 300;
			attackSpeed = 0;
			penetration = 0;

			recoil = 1f;
			recoilRecovery = 0;
			accuracy = 0f;
			spread = 1f;
			rounds = 0;
			reloadSpeed = 1f;

			criticalChance = 0;
			criticalDamage = 0;
		}

		public void Merge(Statistics target) {
			Debug.Log("======");
			Debug.Log(damageCap);
			Debug.Log(target.damageCap);
			damage += target.damage;
			damageCap = Math.Min(damageCap, target.damageCap);
			attackSpeed += target.attackSpeed;
			penetration += target.penetration;

			recoil *= target.recoil;
			recoilRecovery += target.recoilRecovery;
			accuracy = Math.Max(accuracy, target.accuracy);
			spread *= target.spread;
			rounds += target.rounds;
			reloadSpeed *= target.reloadSpeed;

			criticalChance += target.criticalChance;
			criticalDamage += target.criticalDamage;
			Debug.Log(damageCap);
			Debug.Log("======");
		}

		public void DisplayStat(StatDisplay[] displays) {
			displays[0].SetStatus(300, Math.Min(damage, damageCap), damage, Math.Min(damage, damageCap).ToString());
			displays[1].SetStatus(1200, attackSpeed, 0f, attackSpeed.ToString());
			displays[2].SetStatus(100, penetration, 0f, penetration.ToString());
			displays[3].SetStatus(300, recoil, 0f, recoil.ToString());
			displays[4].SetStatus(300, recoilRecovery, 0f, recoilRecovery.ToString());
			displays[5].SetStatus(30, 30 - accuracy, 0f, accuracy.ToString());
			displays[6].SetStatus(10, 10 - spread, 0f, spread.ToString());
			displays[7].SetStatus(100, rounds, 0f, rounds.ToString());
			displays[8].SetStatus(4, reloadSpeed, 0f, reloadSpeed.ToString());
			displays[9].SetStatus(1, criticalChance, 0f, ( criticalChance * 100 ) + "%");
			displays[10].SetStatus(3, criticalDamage, 0f, ( criticalDamage * 100 ) + "%");
		}
	}
}