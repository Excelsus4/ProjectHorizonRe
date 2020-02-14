using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxNotifierManager : MonoBehaviour {
	public static LootBoxNotifierManager g_Notifier;

	public SpriteRenderer m_PartSprite;
	public UnityEngine.UI.Text m_Grade;
	public UnityEngine.UI.Text m_ItemName;
	public UnityEngine.UI.Text m_ItemType;
	public UnityEngine.UI.Text m_Indication;
	public UnityEngine.UI.Text m_Numeric;

	[HideInInspector]
	public int m_InventoryBindCode;

	private void Awake()
	{
		g_Notifier = this;
	}

	private void Start()
	{
		gameObject.SetActive(false);
		m_PartSprite.gameObject.SetActive(false);
	}

	public void DisplayItem(WeaponPart Item)
	{
		if (Item == null)
			return;

		gameObject.SetActive(true);
		m_PartSprite.gameObject.SetActive(true);

		m_PartSprite.sprite = GlobalDatabase.GetWeaponPartSprite(Item.P_SpriteIndex);
		switch (Item.P_PartGrade)
		{
			case WeaponPart.PartGrade.PrivateGrade:
				m_Grade.text = @"[민간]";
				break;
			case WeaponPart.PartGrade.MilitaryGrade:
				m_Grade.text = @"[군용]";
				break;
			case WeaponPart.PartGrade.ModifiedGrade:
				m_Grade.text = @"[특수]";
				break;
			case WeaponPart.PartGrade.SpecialGrade:
				m_Grade.text = @"[걸작]";
				break;
		}
		m_ItemName.text = Item.P_Name;
		switch (Item.P_PartType)
		{
			case WeaponPart.PartType.Barrel:
				m_ItemType.text = @"총열";
				break;
			case WeaponPart.PartType.Blade:
				m_ItemType.text = @"검날";
				break;
			case WeaponPart.PartType.Handle:
				m_ItemType.text = @"손잡이";
				break;
			case WeaponPart.PartType.Magazine:
				m_ItemType.text = @"탄알집";
				break;
			case WeaponPart.PartType.Muzzle:
				m_ItemType.text = @"총구부착물";
				break;
			case WeaponPart.PartType.Pistol:
				m_ItemType.text = @"권총";
				break;
			case WeaponPart.PartType.Receiver:
				m_ItemType.text = @"총몸";
				break;
			case WeaponPart.PartType.Sight:
				m_ItemType.text = @"광학장비";
				break;
			case WeaponPart.PartType.Stock:
				m_ItemType.text = @"개머리판";
				break;
		}
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

		m_Numeric.text = @"";
		for (int idi = 0; idi < Item.P_SpecValue.Length; idi++)
		{
			m_Numeric.text += GetStat((WeaponPart.Specification)idi, Item) + @"
";
		}
	}

	private string GetStat(WeaponPart.Specification StatNo, WeaponPart thisPart)
	{
		switch (StatNo)
		{
			case WeaponPart.Specification.Weight:
				return (thisPart.P_SpecValue[(int)StatNo]).ToString() + @" lbs";
			case WeaponPart.Specification.AttackDamage:
			case WeaponPart.Specification.Rounds:
				return Mathf.CeilToInt((float)thisPart.P_SpecValue[(int)StatNo]).ToString();
			case WeaponPart.Specification.CriticalChance:
			case WeaponPart.Specification.CriticalDamage:
			case WeaponPart.Specification.PiercePercent:
				return ((float)thisPart.P_SpecValue[(int)StatNo] * 100f).ToString() + @"%";
			case WeaponPart.Specification.AttackType:
				//TODO: There is some problem with this Part
				return thisPart.P_SpecValue[(int)StatNo].ToString();
			default:
				return ((float)thisPart.P_SpecValue[(int)StatNo]).ToString();
		}
	}

	public void CloseDisplay()
	{
		gameObject.SetActive(false);
		m_PartSprite.gameObject.SetActive(false);
	}

	public void TryThis()
	{
		if (EquipmentManager.m_SelectedWeapon == -1)
			return;

		WeaponPart temp = GlobalWeaponData.g_AllWeapon[EquipmentManager.m_SelectedWeapon].ChangeWeaponPart(GlobalWeaponData.GetWeaponPart(m_InventoryBindCode));
		GlobalWeaponData.RemoveWeaponPart(m_InventoryBindCode);
		GlobalWeaponData.AddWeaponPart(temp);
		SimpleMessageConsole.g_GlobalOne.MakeMessage("무기 부품이 장착되었습니다!");
		GlobalWeaponData.GlobalRefresh();
		CloseDisplay();
	}
}
