using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleInventoryRenderer : MonoBehaviour {
	public Image m_Backboard;
	public Image m_Icon;
	public Text m_NameText;

	[HideInInspector]
	public int RendererCode;
	[HideInInspector]
	public InventoryManager Parent;

	public void MovePosition(int idi)
	{
		transform.Translate(0, -30 * idi, 0);
	}

	public void ButtonCallback()
	{
		Parent.CallbackInventory(RendererCode);
	}

	public bool Enable
	{
		set
		{
			m_Backboard.enabled = value;
			m_Icon.enabled = value;
			m_NameText.enabled = value;
		}
	}

	public void ChangeState(WeaponPart.PartGrade grade, WeaponPart.PartType partType, int spriteIndex, string name)
	{
		//등급별 백보드 설정
		switch (grade)
		{
			case WeaponPart.PartGrade.PrivateGrade:
				m_Backboard.color = Color.white;
				break;
			case WeaponPart.PartGrade.MilitaryGrade:
				m_Backboard.color = Color.green;
				break;
			case WeaponPart.PartGrade.ModifiedGrade:
				m_Backboard.color = Color.yellow;
				break;
			case WeaponPart.PartGrade.SpecialGrade:
				m_Backboard.color = Color.red;
				break;
		}

		//아이템 스프라이트 겟
		m_Icon.sprite = GlobalDatabase.GetWeaponPartSprite(spriteIndex);

		//이름 설정
		m_NameText.text = name;
	}
}
