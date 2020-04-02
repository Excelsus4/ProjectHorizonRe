using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.PlayerDamager {
	public class PlayerDamager : MonoBehaviour {
		public PlayerBindStat stat;
		private int currentHP;

		private void Awake() {
			stat = PlayerStatData.getSingleton().playerData;
			currentHP = stat.maxHP;
		}
	}
}