﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Menu Button Click Action Scripts
	public void OnClickArmory()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Equipment");
	}

	public void OnClickDrive()
	{

	}

	public void OnClickBattle()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("CharacterMovementTest");
	}

	public void OnClickOption()
	{

	}

	public void OnClickExit()
	{

	}
}
