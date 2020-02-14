using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleEquipmentRenderer : MonoBehaviour
{
	public Image m_Backboard;
	public Image m_Icon;

	public void MovePosition(int idi)
	{
		transform.Translate(70 * idi, 0, 0);
	}

	public bool Enable
	{
		set
		{
			m_Backboard.enabled = value;
			m_Icon.enabled = value;
		}
	}

	public void ChangeState(WeaponPart.PartGrade grade, WeaponPart.PartType partType, int spriteIndex)
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
	}
}
