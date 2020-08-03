using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.Shooting.TrailBullet {
	public class BulletTrail : MonoBehaviour {
		public float Speed;
		private Vector2 start;
		private Vector2 end;
		private float p;
		// speed over the distance (0 to 1)
		private float rSpeed;

		public void SetTrail(Vector2 Start, Vector2 End) {
			start = Start;
			end = End;
			p = 0;
			rSpeed = Speed / Vector2.Distance(start, end) + (Random.value * 0.5f);
		}

		private void Update() {
			p += Time.deltaTime * rSpeed;
			transform.position = Vector2.Lerp(start, end, p);
			if (p > 1.2f)
				Destroy(gameObject);
		}
	}
}