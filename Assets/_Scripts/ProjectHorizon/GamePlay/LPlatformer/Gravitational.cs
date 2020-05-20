using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer {
	public class Gravitational : MonoBehaviour {
		public LayerMask FloorMask;
		public float FootLength = 0.5f;
		public bool IsGrounded { get; private set; }
		public float gravity = 0.98f;
		private Vector2 groundNormal;
		private Vector2 velocity;

		private void FixedUpdate() {
			RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector2.down, FootLength, FloorMask);
			if (raycastHit.collider) {
				transform.Translate(0f, (FootLength/2) - raycastHit.distance, 0f);
				IsGrounded = true;
				groundNormal = raycastHit.normal;
			} else {
				IsGrounded = false;
			}

			PerformTranslation();
		}

		private void PerformTranslation() {
			if (!IsGrounded) {
				velocity.y -= gravity;
				if(velocity.y * Time.deltaTime < -FootLength) {
					velocity.y = -FootLength / Time.deltaTime;
				}
			} else {
				velocity.y = 0f;
			}
			
			transform.Translate(velocity*Time.deltaTime);
		}

		public void Move(float xVelocity) {
			if (IsGrounded) {
				velocity.x = xVelocity;
			}
		}

		public void Jump(float Force) {
			velocity += groundNormal * Force;
			transform.Translate(0f, FootLength / 2, 0f);
		}
	}
}