﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.ProjectHorizon.GamePlay.Shooting;
using TouchControlsKit;

	namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer {
	public class PlayerControl : MonoBehaviour {
		public Gravitational gravitational;
		public VoxelAnimationControl animationControl;
		public VoxelInputControl legacyInputControl;
		public float tempMoveSpeed;
		public float tempJumpForce;
		public float tempAerialSpeed;
		public float moveJoystickThreshold;
		public float crouchDepth;
		public ProjectHorizon.GamePlay.CameraControl.CameraControl cameraControl;
		public float defaultCameraSize;
		public float zoomMultiplier;

		private bool isCrouch;
		private Vector3 aimMemory;

		private void Awake() {
			if (!gravitational)
				gravitational = GetComponentInParent<Gravitational>();
			if (!animationControl)
				animationControl = GetComponent<VoxelAnimationControl>();
			if (!legacyInputControl)
				legacyInputControl = GetComponent<VoxelInputControl>();
			aimMemory = new Vector3(1f, 0f, 0f);
			CameraControl();
		}

		private void Update() {
			// This if is for isControllable
			if (true) {
				float xMovement = TCKInput.GetAxis("LJoystick").x;
				float yMovement = TCKInput.GetAxis("LJoystick").y;
				if (xMovement != 0f || yMovement != 0f) {
					aimMemory.x = xMovement;
					aimMemory.y = yMovement;
				}

				if (TCKInput.GetAction("Crouch", EActionEvent.Click)) {
					ToggleCrouch();
					CameraControl();
				} else if (xMovement != 0f)
					CameraControl();

				legacyInputControl.Aim(aimMemory);
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

		private void ToggleCrouch() {
			isCrouch = !isCrouch;
			animationControl.SetCrouch(isCrouch);
			transform.Translate(.0f, isCrouch ? -crouchDepth : crouchDepth, .0f);
		}

		private void CameraControl() {
			cameraControl.SetSize(isCrouch ? defaultCameraSize*zoomMultiplier : defaultCameraSize);
			cameraControl.offset.x = isCrouch ? ( aimMemory.x > 0 ? defaultCameraSize * zoomMultiplier : -defaultCameraSize * zoomMultiplier ) : 0f;
		}
	}
}