using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.Modules.NumberedDamage;
using com.meiguofandian.ProjectHorizon.GamePlay.PlayerDamager;

namespace com.meiguofandian.ProjectHorizon.GamePlay.Shootables {
	public class MobCollidingAttack : MonoBehaviour {
		public IMobAnimation anim;
		public DamageSkin damageSkin;
		public int damage;

		private PlayerCharacterDamager targetDamager;

		private void Awake() {
			anim = GetComponentInParent<IMobAnimation>();
		}

		private void OnTriggerEnter2D(Collider2D collision) {
			anim.StartMelee();
			targetDamager = collision.GetComponent<PlayerCharacterDamager>();
		}

		private void OnTriggerStay2D(Collider2D collision) {
			targetDamager.TryDamage(damage, damageSkin);
		}

		private void OnTriggerExit2D(Collider2D collision) {
			anim.StopMelee();
		}
	}
}