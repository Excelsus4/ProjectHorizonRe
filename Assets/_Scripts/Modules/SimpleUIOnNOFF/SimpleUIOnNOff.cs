using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.Modules.SimpleUIOnNOff {
	public class SimpleUIOnNOff : MonoBehaviour {
		public GameObject[] boundedToBeON;
		public GameObject[] boundedToBeOFF;
		public bool includeSelf;

		public void Activate() {
			Activate(true);
		}

		public void Activate(bool dir) {
			foreach (GameObject @object in boundedToBeON)
				@object.SetActive(dir);
			foreach (GameObject @object in boundedToBeOFF)
				@object.SetActive(!dir);
			if (includeSelf)
				gameObject.SetActive(!dir);
		}
	}
}