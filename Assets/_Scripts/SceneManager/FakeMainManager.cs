using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeMainManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	}

	private void Update()
	{
		//Initialize Global Data
		GlobalWeaponData.g_AllWeapon = new Weapon[4];
		GlobalWeaponData.g_AllWeapon[0] = new MainWeapon();
		GlobalWeaponData.g_AllWeapon[1] = new MainWeapon();
		GlobalWeaponData.g_AllWeapon[2] = new SubWeapon();
		GlobalWeaponData.g_AllWeapon[3] = new Bayonet();

		GlobalWeaponData.g_CurrentWeapon = GlobalWeaponData.g_AllWeapon[0];

		//Load Save File Data
	}

	private void LateUpdate()
	{
		//Finish Loading
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}
}
