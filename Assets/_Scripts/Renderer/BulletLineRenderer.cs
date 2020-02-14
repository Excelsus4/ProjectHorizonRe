using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLineRenderer : MonoBehaviour {
	public LineRenderer lr;
	public float speed;

	// Update is called once per frame
	void Update () {
		lr.startColor = lr.endColor = Color.Lerp(lr.startColor, new Color(128, 128, 128, 0f), speed * Time.deltaTime);
	}
}
