using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.Projectile {
	public class HostileProjectile : MonoBehaviour {
		public float ProjectileSpeed;


		// Start is called before the first frame update
		void Start() {
		}

		// Update is called once per frame
		void Update() {
			transform.Translate(Vector3.forward * ProjectileSpeed * Time.deltaTime);
		}

		public void DirectToward(Vector3 target) {
			transform.LookAt(target);
		}
	}
}