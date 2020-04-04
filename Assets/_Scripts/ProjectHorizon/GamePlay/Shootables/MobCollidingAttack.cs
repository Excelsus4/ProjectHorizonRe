using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.Modules.NumberedDamage;

namespace com.meiguofandian.ProjectHorizon.GamePlay.Shootables {
	public class MobCollidingAttack : MonoBehaviour {
		public IMobAnimation anim;
		public DamageSkin damageSkin;

		private void Awake() {
			anim = GetComponentInParent<IMobAnimation>();
		}

		private void OnTriggerEnter2D(Collider2D collision) {
			anim.StartMelee();
		}

		private void OnTriggerExit2D(Collider2D collision) {
			anim.StopMelee();
		}
	}
}