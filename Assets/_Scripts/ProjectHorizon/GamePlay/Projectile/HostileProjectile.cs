using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.ProjectHorizon.GamePlay.Shootables;
using com.meiguofandian.ProjectHorizon.GamePlay.PlayerDamager;

namespace com.meiguofandian.ProjectHorizon.GamePlay.Projectile {
	public class HostileProjectile : MonoBehaviour {
		public float ProjectileSpeed;
		public MobProjectileAttack ParentAttacker;
		private PlayerCharacterDamager targetDamager;

		// Start is called before the first frame update
		void Start() {
		}

		// Update is called once per frame
		void Update() {
			transform.parent.Translate(Vector3.forward * ProjectileSpeed * Time.deltaTime);
		}

		public void DirectToward(Vector3 target) {
			transform.parent.LookAt(target);
		}

		private void OnTriggerEnter2D(Collider2D collision) {
			// Call Damager
			targetDamager = collision.GetComponent<PlayerCharacterDamager>();
			targetDamager.TryDamage(ParentAttacker.damage, ParentAttacker.damageSkin);

			// Call Destructor
			// Add Destruction Effect HERE
			Destroy(transform.parent.gameObject);
		}
	}
}