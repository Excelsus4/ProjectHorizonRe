using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.Miscellaneous {
	public class BlobManager : MonoBehaviour {
		[HideInInspector]
		public Transform Target;
		[HideInInspector]
		public int ResourceAmount;
		public CharacterData.ResourceType ResourceType;
		[HideInInspector]
		public float Acceleration;
		[HideInInspector]
		public float GravityTime;

		private Rigidbody2D RigidbodyHere;
		private float TimeFlow;
		private float Velocity;

		// Use this for initialization
		void Start() {
			TimeFlow = 0;
			RigidbodyHere = gameObject.GetComponent<Rigidbody2D>();
			RigidbodyHere.AddForce(Vector2.up * 200f);
			GravityTime = 0.7f;
			Acceleration = 1f;
			Velocity = 0f;
		}

		// Update is called once per frame
		void Update() {
			TimeFlow += Time.deltaTime;
			if (TimeFlow > GravityTime) {
				Velocity += Acceleration;
				RigidbodyHere.bodyType = RigidbodyType2D.Kinematic;
				Vector3 displacement = Target.position - transform.position;
				if (displacement.magnitude < Velocity * Time.deltaTime)
					Remove();
				else {
					displacement.Normalize();
					transform.Translate(displacement * Velocity * Time.deltaTime);
				}
			}
		}

		private void Remove() {
			CharacterData.AddResource(ResourceType, ResourceAmount);
			Destroy(gameObject);
			//ADD Resource algorithm
		}
	}
}