using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.ProjectHorizon.GamePlay.Shooting;
using TouchControlsKit;

	namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer {
	public class PlayerControl : MonoBehaviour {
		public Gravitational gravitational;
		public VoxelAnimationControl animationControl;
		public float tempMoveSpeed;
		public float tempJumpForce;
		public float tempAerialSpeed;
		public float moveJoystickThreshold;

		private void Awake() {
			if (!gravitational)
				gravitational = GetComponentInParent<Gravitational>();
			if (!animationControl)
				animationControl = GetComponent<VoxelAnimationControl>();
		}

		private void Update() {
			// This if is for isControllable
			if (true) {
				float xMovement = TCKInput.GetAxis("LJoystick").x;
				xMovement = Mathf.Abs(xMovement) > moveJoystickThreshold ? xMovement : 0f;
				if (gravitational.IsGrounded) {
					animationControl.SetWalkingSpeed(xMovement);
					xMovement *= tempMoveSpeed;
					gravitational.Move(xMovement);
					if (TCKInput.GetAction("Jump", EActionEvent.Press))
						gravitational.Jump(tempJumpForce);
				} else {
					xMovement *= tempAerialSpeed * Time.deltaTime;
					gravitational.Move(xMovement);
				}
			}
		}
	}
}