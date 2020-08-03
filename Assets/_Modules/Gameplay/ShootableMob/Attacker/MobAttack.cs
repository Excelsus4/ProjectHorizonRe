using System.Collections;
using System.Collections.Generic;
using com.meiguofandian.Modules.NumberedDamage;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.Shootables {
	public class MobAttack : MonoBehaviour {
		public IMobAnimation anim;
		public DamageSkin damageSkin;

		private void Awake() {
			anim = GetComponentInParent<IMobAnimation>();
		}

		// Start is called before the first frame update
		void Start() {

		}

		// Update is called once per frame
		void Update() {

		}
	}
}