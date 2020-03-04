using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.weaponMod {
	[Serializable]
	public class Statistics {
		// Offensive
		public int damage;
		public float criticalChance;
		public float criticalDamage;
		public int penetration;
		public float accuracy;
		public float recoil = 1f;
		public float recoilRecovery = 1f;
		public float spread;

		// Defensive

		// Methods
		public void Reset() {
			damage = 0;
			criticalChance = 0;
			criticalDamage = 1f;
			penetration = 0;
			accuracy = 1f;
			recoil = 1f;
			recoilRecovery = 1f;
			spread = 1f;
		}

		public void Merge(Statistics target) {
			damage += target.damage;
			criticalChance += target.criticalChance;
			criticalDamage += target.criticalDamage;
			penetration += target.penetration;
			accuracy *= target.accuracy;
			recoil *= target.recoil;
			recoilRecovery *= target.recoilRecovery;
			spread *= target.spread;
		}
	}
}