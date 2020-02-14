using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
	//RENEWAL SCRIPT
	public GameObject m_UIParent;

	public GameObject m_UIObjectWeaponSelect;
	public GameObject m_UIWeaponSelect;

	public GameObject m_UISpecific;

	public UnityEngine.UI.Text m_Title;
	public UnityEngine.UI.Text m_Indication;
	public UnityEngine.UI.Text m_Numeric;

	public InventoryNewManager m_Inventory;

	public SpriteRenderer[] m_SinglePartRenderer;
	public WeaponRenderer[] m_WeaponRenderer;

	public static int m_SelectedWeapon;

	public void Refresh()
	{
		UpdateWeaponRenderer();
		UpdateWeaponStats();
	}

	public void UpdateWeaponRenderer()
	{
		//TODO:
		//WeaponObject에서 각 렌더러의 무기 스프라이트 갱신
		for (int idi = 0; idi < GlobalWeaponData.g_AllWeapon[m_SelectedWeapon].GetPartRequiredLength(); idi++)
		{
			if (GlobalWeaponData.g_AllWeapon[m_SelectedWeapon].GetPartByIndex(idi) != null)
			{
				m_SinglePartRenderer[idi].gameObject.SetActive(true);
				m_SinglePartRenderer[idi].sprite = GlobalDatabase.GetWeaponPartSprite(GlobalWeaponData.g_AllWeapon[m_SelectedWeapon].GetPartByIndex(idi).P_SpriteIndex);
			}
		}
	}

	public void UpdateWeaponStats()
	{
		//TODO:
		m_Indication.text = @"Weight:
Damage:
RPM:
Type:
Critical Damage:
Critical Chance:
Percent Pierce:
Fixed Pierce:
Stability:
Accuracy:
Recovery:
Max Rounds:
Reload Speed:";

		m_Numeric.text = "";
		for(int idi = 0; idi < GlobalWeaponData.g_AllWeapon[m_SelectedWeapon].m_CurrentStatus.Length; idi++)
		{
			m_Numeric.text += GetStat((WeaponPart.Specification)idi) + @"
";
		}

		m_Inventory.Refresh();

		//WeaponStats Text에 WeaponStats 출력
	}

	private string GetStat(WeaponPart.Specification StatNo)
	{
		switch (StatNo)
		{
			case WeaponPart.Specification.Weight:
				return GlobalWeaponData.g_AllWeapon[m_SelectedWeapon].m_CurrentStatus
					[(int)StatNo].ToString()+@" lbs";
			case WeaponPart.Specification.AttackDamage:
			case WeaponPart.Specification.Rounds:
				return Mathf.CeilToInt((float)GlobalWeaponData.g_AllWeapon[m_SelectedWeapon].m_CurrentStatus
					[(int)StatNo]).ToString();
			case WeaponPart.Specification.CriticalChance:
			case WeaponPart.Specification.CriticalDamage:
			case WeaponPart.Specification.PiercePercent:
				return ((float)GlobalWeaponData.g_AllWeapon[m_SelectedWeapon].m_CurrentStatus
					[(int)StatNo] * 100f).ToString() + @"%";
			case WeaponPart.Specification.AttackType:
				//TODO: There is some problem with this Part
				return (string)GlobalWeaponData.g_AllWeapon[m_SelectedWeapon].m_CurrentStatus[(int)StatNo];
			default:
				return GlobalWeaponData.g_AllWeapon[m_SelectedWeapon].m_CurrentStatus
					[(int)StatNo].ToString();
		}
	}

	public void UIEnable()
	{
		GlobalWeaponData.EquipmentManagerCallback = this;
		m_UIParent.SetActive(true);
		m_UIWeaponSelect.SetActive(true);
		m_UIObjectWeaponSelect.SetActive(true);

		for(int idi = 0; idi < m_WeaponRenderer.Length; idi++)
		{
			//m_WeaponRenderer[idi].UpdateToCurrent();
		}
	}

	public void WeaponSelect(int idw)
	{
		m_UIWeaponSelect.SetActive(false);
		m_UIObjectWeaponSelect.SetActive(false);
		m_UISpecific.SetActive(true);
		switch (idw)
		{
			case 0:
				m_Title.text = "Primary Weapon";
				break;
			case 1:
				m_Title.text = "Secondary Weapon";
				break;
			case 2:
				m_Title.text = "Emergency Weapon";
				break;
			case 3:
				m_Title.text = "Close Combat Weapon";
				break;
		}
		m_SelectedWeapon = idw;
		UpdateWeaponStats();
		UpdateWeaponRenderer();
	}

	public void UIDisable()
	{
		GlobalWeaponData.EquipmentManagerCallback = null;
		m_UIParent.SetActive(false);
		m_UIWeaponSelect.SetActive(false);
		m_UIObjectWeaponSelect.SetActive(false);
		m_UISpecific.SetActive(false);
		m_SelectedWeapon = -1;
		for (int idi = 0; idi < m_SinglePartRenderer.Length; idi++)
			m_SinglePartRenderer[idi].gameObject.SetActive(false);
	}
}
