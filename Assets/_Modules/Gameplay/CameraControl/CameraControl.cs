using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.CameraControl {
	public class CameraControl : MonoBehaviour {
		public Transform player;
		public float speed;
		public Vector3 offset;
		public float size;
		public Camera cameraComponent;

		private void Awake() {
			if (!cameraComponent)
				cameraComponent = GetComponent<Camera>();
		}

		private void Update() {
			transform.position = Vector3.Lerp(transform.position, player.position + offset, speed * Time.deltaTime);
			cameraComponent.orthographicSize = Mathf.Lerp(cameraComponent.orthographicSize, size, speed * Time.deltaTime);
		}

		public void SetSize(float size) {
			this.size = size;
		}
	}
}