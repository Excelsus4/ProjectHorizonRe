using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.Shootables {
	public class FloatingAnimationManager : MonoBehaviour, IMobAnimation {
		public float BounceSpeed;
		public float BounceAmount;

		private float bounce;

		private void Start() {
			bounce = Random.Range(0f, BounceSpeed);
		}

		private void Update(){
			bounce += Time.deltaTime;
			float t = bounce % BounceSpeed / BounceSpeed * 2;
			transform.localPosition = Vector3.up*Vector3.Slerp(Vector3.down * BounceAmount, Vector3.up * BounceAmount, t > 1 ? 2 - t : t).y;
		}

		public void Attacked() {
		}

		public void Death() {
		}

		public void StartMelee() {
		}

		public void StopMelee() {
		}
	}
}