using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.meiguofandian.ProjectHorizon.GamePlay.Shooting.Shell {
	public class AutoDelete : MonoBehaviour {
		public float life;

		// Use this for initialization
		void Start() {
			Destroy(gameObject, life);
		}
	}
}