using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAnimationManager : MonoBehaviour
{
	public SpriteRenderer MobRenderer;

	public Sprite MobIdle;
	public Sprite MobAttacked;

	public float StopTime;
	private float TimeElapsed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (TimeElapsed > StopTime)
			MobRenderer.sprite = MobIdle;
		else
			TimeElapsed += Time.deltaTime;
	}

	public void Attacked()
	{
		MobRenderer.sprite = MobAttacked;
		TimeElapsed = 0;
	}

	public void Death()
	{
	}
}
