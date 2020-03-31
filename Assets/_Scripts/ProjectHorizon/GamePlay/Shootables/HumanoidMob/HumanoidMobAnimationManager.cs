using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.Shootables.HumanoidMob {
	public class HumanoidMobAnimationManager : MonoBehaviour, IMobAnimation {
		public Animator animator;

		public void Attacked() {
			animator.SetTrigger("Groggy");
		}

		public void StartMelee() {
			animator.SetBool("MeleeAttack", true);
		}

		public void StopMelee() {
			animator.SetBool("MeleeAttack", false);
		}

		public void Death() {
			animator.SetTrigger("Death");
		}
	}
}