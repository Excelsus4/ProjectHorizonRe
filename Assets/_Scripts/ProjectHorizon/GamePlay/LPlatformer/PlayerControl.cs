using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.ProjectHorizon.GamePlay.Shooting;

	namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer {
	public class PlayerControl : MonoBehaviour {
		public Gravitational gravitational;
		public VoxelAnimationControl animationControl;
		public float tempMoveSpeed;
		public float tempJumpForce;
		public float tempAerialSpeed;

		private void Awake() {
			if (!gravitational)
				gravitational = GetComponentInParent<Gravitational>();
			if (!animationControl)
				animationControl = GetComponent<VoxelAnimationControl>();
		}

		private void Update() {
			// This if is for isControllable
			if (true) {
				if (gravitational.IsGrounded) {
					float xMovement = Input.GetAxis("Horizontal");
					animationControl.SetWalkingSpeed(xMovement);
					xMovement *= tempMoveSpeed;
					gravitational.Move(xMovement);
					if (Input.GetButton("Jump"))
						gravitational.Jump(tempJumpForce);
				} else {
					float xMovement = Input.GetAxis("Horizontal");
					xMovement *= tempAerialSpeed * Time.deltaTime;
					gravitational.Move(xMovement);
				}
			}
		}
	}
}