using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.Shootables {
	public class MobCollidingAttack : MonoBehaviour {
		public IMobAnimation anim;

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