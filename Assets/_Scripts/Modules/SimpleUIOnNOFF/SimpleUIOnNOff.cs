using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.Modules.SimpleUIOnNOff {
	public class SimpleUIOnNOff : MonoBehaviour {
		public GameObject[] boundedToBeON;
		public GameObject[] boundedToBeOFF;
		public bool includeSelf;

		public void Activate() {
			foreach(GameObject @object in boundedToBeON)
				@object.SetActive(true);
			foreach(GameObject @object in boundedToBeOFF)
				@object.SetActive(false);
			if (includeSelf)
				gameObject.SetActive(false);
		}
	}
}