using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code modified from unity MicrogamePlatformer Tutorial
namespace com.meiguofandian.platformer {
	/// <summary>
	/// This is the main class used to implement control of the player.
	/// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
	/// </summary>
	public class PlayerController : KinematicObject {
		public AudioClip jumpAudio;
		public AudioClip respawnAudio;
		public AudioClip ouchAudio;

		/// <summary>
		/// Max horizontal speed of the player.
		/// </summary>
		public float maxSpeed = 7;
		/// <summary>
		/// Initial jump velocity at the start of a jump.
		/// </summary>
		public float jumpTakeOffSpeed = 7;

		public JumpState jumpState = JumpState.Grounded;
		private bool stopJump;
		/*internal new*/
		public Collider2D collider2d;
		/*internal new*/
		public AudioSource audioSource;
		public bool controlEnabled = true;
		public VoxelInputControl upperInputControl;

		bool jump;
		Vector2 move;
		//SpriteRenderer spriteRenderer;
		//internal Animator animator;
		internal VoxelAnimationControl animator;
		readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

		public Bounds Bounds => collider2d.bounds;

		void Awake() {
			audioSource = GetComponent<AudioSource>();
			collider2d = GetComponent<Collider2D>();
			//spriteRenderer = GetComponent<SpriteRenderer>();
			animator = GetComponent<VoxelAnimationControl>();
			upperInputControl = GetComponent<VoxelInputControl>();
		}

		protected override void Update() {
			if (controlEnabled) {
				move.x = Input.GetAxis("Horizontal");
				if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
					jumpState = JumpState.PrepareToJump;
				else if (Input.GetButtonUp("Jump")) {
					stopJump = true;
					Simulation.Schedule<PlayerStopJump>().player = this;
				}
			} else {
				move.x = 0;
			}
			UpdateJumpState();
			base.Update();
		}

		void UpdateJumpState() {
			jump = false;
			switch (jumpState) {
			case JumpState.PrepareToJump:
				jumpState = JumpState.Jumping;
				jump = true;
				stopJump = false;
				break;
			case JumpState.Jumping:
				if (!IsGrounded) {
					Simulation.Schedule<PlayerJumped>().player = this;
					jumpState = JumpState.InFlight;
				}
				break;
			case JumpState.InFlight:
				if (IsGrounded) {
					Simulation.Schedule<PlayerLanded>().player = this;
					jumpState = JumpState.Landed;
				}
				break;
			case JumpState.Landed:
				jumpState = JumpState.Grounded;
				break;
			}
		}

		protected override void ComputeVelocity() {
			if (jump && IsGrounded) {
				velocity.y = jumpTakeOffSpeed * model.jumpModifier;
				jump = false;
			} else if (stopJump) {
				stopJump = false;
				if (velocity.y > 0) {
					velocity.y = velocity.y * model.jumpDeceleration;
				}
			}
			
			animator.SetGrounded(IsGrounded);
			if (upperInputControl.m_isLookingLeft) {
				animator.SetWalkingSpeed(-velocity.x / maxSpeed);
			} else {
				animator.SetWalkingSpeed(velocity.x / maxSpeed);
			}

			targetVelocity = move * maxSpeed;
		}

		public enum JumpState {
			Grounded,
			PrepareToJump,
			Jumping,
			InFlight,
			Landed
		}
	}
}