using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer {
	public class PlayerControl : MonoBehaviour {
		public Gravitational gravitational;
		public float tempMoveSpeed;
		public float tempJumpForce;

		private void Awake() {
			if (!gravitational)
				gravitational = GetComponentInParent<Gravitational>();
		}

		private void Update() {
			// This if is for isControllable
			if (true) {
				if (gravitational.IsGrounded) {
					gravitational.Move(Input.GetAxis("Horizontal")*tempMoveSpeed);
					if (Input.GetButtonDown("Jump"))
						gravitational.Jump(tempJumpForce);
				}
			}
		}
	}
}