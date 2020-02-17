using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
	public VoxelAnimationControl characterMannequin;

	private void Awake() {
		characterMannequin.SetAsMannequin();
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
