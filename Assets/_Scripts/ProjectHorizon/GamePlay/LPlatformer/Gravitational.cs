using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.Modules.ObserverPattern;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer {
	public class Gravitational : MonoBehaviour {
		public LayerMask FloorMask;
		public LayerMask WallMask;
		public float FootLength = 0.5f;
		public float BodySize = 0.2f;
		private bool isGrounded;
		public bool IsGrounded {
			get => isGrounded;
			private set {
				if (isGrounded != value) {
					isGrounded = value;
					foreach (IDataUpdateCallback observer in groundingObservers) {
						observer.OnDataUpdate("Gravitational IsGrounded");
					}
				}
			}
		}
		public float gravity = 0.98f;
		private Vector2 groundNormal;
		private Vector2 velocity;
		private List<IDataUpdateCallback> groundingObservers = new List<IDataUpdateCallback>();

		private void FixedUpdate() {
			// Grounding Check when falling
			if (velocity.y <= 0) {
				RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector2.down, FootLength, FloorMask);
				if (raycastHit.collider) {
					transform.Translate(0f, ( FootLength / 2 ) - raycastHit.distance, 0f);
					IsGrounded = true;
					groundNormal = raycastHit.normal;
					velocity.y = 0f;
				} else {
					IsGrounded = false;
				}
			}

			if (!IsGrounded) {
				velocity.y -= gravity;
				if (velocity.y * Time.deltaTime < -FootLength)
					velocity.y = -FootLength / Time.deltaTime;

				transform.Translate(0, velocity.y * Time.deltaTime, 0);
			}

			// Wall Check when moving sideways
			if(velocity.x != 0) {
				float rayDistance = BodySize + Mathf.Abs(velocity.x) * Time.deltaTime;
				RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, new Vector2(velocity.x > 0 ? 1: -1,0), rayDistance, WallMask);
				if (raycastHit.collider) {
					rayDistance = ( raycastHit.distance - BodySize ) / Time.deltaTime;
					velocity.x = velocity.x > 0 ? rayDistance : -rayDistance ;
					// transform.Translate(0f, ( BodySize / 2 ) - raycastHit.distance, 0f);
				}
			}

			if (velocity.x != 0) {
				if (!IsGrounded) {
					transform.Translate(velocity.x * Time.deltaTime, 0, 0);
				} else {
					Vector2 tangent = new Vector2(groundNormal.y, -groundNormal.x);
					transform.Translate(velocity.x * Time.deltaTime * tangent);
				}
			}
		}

		public void Move(float xVelocity) {
			if (IsGrounded) {
				velocity.x = xVelocity;
			} else {
				velocity.x += xVelocity;
			}
		}

		public void Jump(float Force) {
			velocity += groundNormal * Force;
			transform.Translate(0f, FootLength, 0f);
			IsGrounded = false;
		}

		public void AddGroundingObserver(IDataUpdateCallback observer) {
			groundingObservers.Add(observer);
		}

		public void RemoveGroundingObserver(IDataUpdateCallback observer) {
			groundingObservers.Remove(observer);
		}
	}
}