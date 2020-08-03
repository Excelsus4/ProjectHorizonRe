using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.Modules.SimpleUIOnNOff {
	public class SimpleTouchAnywhere : MonoBehaviour {
		private void Update() {
			if (Input.GetMouseButtonDown(0)) {
				// After reward window, touching anywhere will wrap up everything and return
				// TODO: wrap up.
				UnityEngine.SceneManagement.SceneManager.LoadScene("__Scene/MainMenu");
			}
		}
	}
}