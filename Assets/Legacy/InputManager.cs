using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
	/*public enum ExternalUI
	{
		Inventory,
		Equipment,
		Resource,
		Skill
	}

	private bool[] isUIOn = new bool[4];
	public GameObject[] UIPanel = new GameObject[4];

	private void Awake()
	{
		for (int idi = 0; idi < isUIOn.Length; idi++)
		{
			isUIOn[idi] = true;
			ToggleUI((ExternalUI)idi);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Inventory"))
		{
			ToggleInventory();
		}
		if (Input.GetButtonDown("Equipment"))
		{
			ToggleEquipment();
		}
		if (Input.GetButtonDown("Resource"))
		{
			ToggleResource();
		}
		if (Input.GetButtonDown("Skill"))
		{
			ToggleSkill();
		}
	}

	public void ToggleUI(ExternalUI ui)
	{
		if (isUIOn[(int)ui])
		{
			UIPanel[(int)ui].transform.Translate(-100000f, 0f, 0f);
			isUIOn[(int)ui] = false;
		}
		else
		{
			UIPanel[(int)ui].transform.Translate(100000f, 0f, 0f);
			isUIOn[(int)ui] = true;
		}
	}

	public void ToggleInventory()
	{
		ToggleUI(ExternalUI.Inventory);
	}

	public void ToggleEquipment()
	{
		ToggleUI(ExternalUI.Equipment);
	}

	public void ToggleResource()
	{
		ToggleUI(ExternalUI.Resource);
	}

	public void ToggleSkill()
	{
		ToggleUI(ExternalUI.Skill);
	}*/
}
