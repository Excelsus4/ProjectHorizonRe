using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.ProjectHorizon.GamePlay.PlayerDamager;
using com.meiguofandian.ProjectHorizon.GamePlay.Projectile;

namespace com.meiguofandian.ProjectHorizon.GamePlay.Shootables {
	public class MobProjectileAttack : MobAttack {
		public int damage;
		public GameObject projectilePrefab;
		public float range;
		public float attackSpeed;

		private PlayerCharacterDamager[] targets;
		private float coolTime;

		private void Start() {
		}

		private void Update() {
			if (CheckCooltime()) {
				Shoot();
			}
		}

		private void ScanEnemy() {
			targets = FindObjectsOfType<PlayerCharacterDamager>();
		}

		private bool CheckCooltime() {
			coolTime -= Time.deltaTime;
			return coolTime <= 0;
		}

		private void Shoot() {
			ScanEnemy();

			float min = float.PositiveInfinity;
			PlayerCharacterDamager target = null;
			foreach(PlayerCharacterDamager player in targets) {
				float d = Vector3.Distance(transform.position, player.transform.position);
				if (min > d) {
					min = d;
					target = player;
				}
			}
			if(min < range) {
				HostileProjectile h = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponentInChildren<HostileProjectile>();
				h.ParentAttacker = this;
				h.DirectToward(target.transform.position);
			}

			coolTime = attackSpeed;
		}
	}
}
