using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoManager : MonoBehaviour {
	public Image m_SpriteView;
	public Text m_ItemName;
	public Text m_Grade;
	public Text m_PartType;
	public Text m_Content;

	private WeaponPart m_currentSelection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DisplayThisItem(WeaponPart thisItem)
	{
		m_currentSelection = thisItem;
		m_ItemName.text = thisItem.P_Name;
		m_Grade.text = thisItem.P_PartGrade.ToString();
		m_PartType.text = thisItem.P_PartType.ToString();
	}

	public void Discard()
	{

	}

	public void Upgrade()
	{

	}

	public void Equip()
	{

	}
}
