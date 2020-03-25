using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.meiguofandian.Modules.SmallCharacter {
	public class PaperFlipper : MonoBehaviour {
		private Transform[] transforms;

		private void Awake() {
			transforms = GetComponentsInChildren<Transform>();
		}

		private void Start() {
			Flip();
		}

		public void Flip() {
			foreach (Transform t in transforms) {
				Vector3 p = t.localPosition;
				p.z = -p.z;
				t.localPosition = p;
			}
		}
	}
}