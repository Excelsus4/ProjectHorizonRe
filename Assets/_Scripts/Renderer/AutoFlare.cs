using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFlare : MonoBehaviour {
	private int frame;
	public Sprite[] Flare;
	public float delay;
	private float cool;

	public void StartAnimation()
	{
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		frame = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (frame < 3 && cool <= 0)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = Flare[frame];
			frame++;
			cool = delay;
		}
		else if (cool > 0)
		{
			cool -= Time.deltaTime;
		}
		else
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
