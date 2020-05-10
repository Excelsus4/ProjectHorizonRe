using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.PlayerDamager {
	[Serializable]
	public class PlayerBindStat {
		// Defensive
		public int maxHP;
		public float immuneTime;

		public PlayerBindStat() {
			Reset();
		}

		public void Reset() {
			maxHP = 30;
			immuneTime = 2f;
		}
	}
}