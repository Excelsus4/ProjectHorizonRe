﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using com.meiguofandian.ProjectHorizon.GamePlay.Platformer;
using com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer;
using com.meiguofandian.Modules.ObserverPattern;

namespace com.meiguofandian.ProjectHorizon.GamePlay.Shooting {
	public class VoxelAnimationControl : MonoBehaviour, IDataUpdateCallback {
		public Animator m_HighAnimator;
		public Animator m_LowAnimator;

		public Transform m_HighBody;
		public Transform m_LowBody;

		private Rigidbody2D m_rigidbody;

		//Shell Animation Control
		public GameObject m_ShellRenderer;
		public Transform m_Receiver;
		public float m_ShellUpForce;
		public float m_ShellBackForce;

		//Character Bound UI
		public UnityEngine.UI.Slider m_BulletIndicator;

		//LPlatformer Link
		public Gravitational gravitational;

		private bool PrevLookBack;

		// Use this for initialization
		private void Awake() {
			m_rigidbody = GetComponent<Rigidbody2D>();
			PrevLookBack = true;

			if (!gravitational)
				gravitational = GetComponentInParent<Gravitational>();
			gravitational.AddGroundingObserver(this);
		}

		private void Start() {
		}

		private void FixedUpdate() {
		}

		public void Fire(float Speed) {
			m_HighAnimator.SetTrigger("Fire");
			m_HighAnimator.speed = Speed;
		}

		public void SetWalkingSpeed(float speed) {
			float tempSpeed = PrevLookBack ? -speed : speed;
			m_LowAnimator.SetFloat("MovingSpeed", tempSpeed);
			if (Mathf.Abs(tempSpeed) > 1)
				m_LowAnimator.speed = Mathf.Abs(tempSpeed);
			else
				m_LowAnimator.speed = 1;
		}

		public void SetGrounded(bool isGrounded) {
			m_LowAnimator.SetBool("onGround", isGrounded);
		}

		public void LookAt(float Angle, bool LookBack) {
			if (LookBack != PrevLookBack) {
				PrevLookBack = LookBack;
			}
			float AngleClip = Angle;
			if (AngleClip > 60f)
				AngleClip = 60f;
			else if (AngleClip < -60f)
				AngleClip = -60f;
			m_HighBody.rotation = Quaternion.Euler(m_HighBody.rotation.eulerAngles.x, LookBack ? 0f : 180f, LookBack ? AngleClip : -AngleClip);
			m_LowBody.rotation = Quaternion.Euler(m_LowBody.rotation.eulerAngles.x, LookBack ? 0f : 180f, 0f);
		}

		public void SetUnstability(float Angle) {

		}

		/// <summary>
		/// This will make this player character just a mannequin rather than a character.
		/// Used probably in the title screen.
		/// </summary>
		public void SetAsMannequin() {
			m_HighAnimator.SetBool("isTitle", true);
			GetComponent<VoxelInputControl>().enabled = false;
			GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
			m_BulletIndicator.gameObject.SetActive(false);
			m_LowAnimator.SetBool("onGround", true);
		}

		public void GenerateShell() {
			// TODO: apply Pool here.
			Instantiate(m_ShellRenderer, m_Receiver.position, Quaternion.Euler(0, 0, 0)).GetComponent<Rigidbody2D>().AddForce(Random.Range(0.9f, 1.1f) * m_Receiver.up * m_ShellUpForce - m_Receiver.forward * m_ShellBackForce);
		}

		public void UpdateBulletIndicator(int Max, int Current) {
			m_BulletIndicator.maxValue = Max * 3;
			m_BulletIndicator.value = Current;
		}

		public void Reload() {
			m_HighAnimator.SetTrigger("Reload");
		}

		public void OnDataUpdate(string data) {
			string[] tokens = data.Split(' ');
			switch (tokens[0]) {
			case "Gravitational":
				SetGrounded(gravitational.IsGrounded);
				break;
			}
		}

		public void SetCrouch(bool isCrouch) {
			m_LowAnimator.SetBool("isCrouch", isCrouch);
		}
	}
}