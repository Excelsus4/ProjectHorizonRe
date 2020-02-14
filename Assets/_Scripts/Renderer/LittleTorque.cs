using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleTorque : MonoBehaviour {
	public float torque;

	private void Start()
	{
		torque = Random.Range(-torque, torque);
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, torque * Time.deltaTime);
	}
}
