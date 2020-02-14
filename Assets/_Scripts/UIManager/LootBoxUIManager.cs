using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxUIManager : MonoBehaviour {
	public Animator m_LootBoxAnimation;
	public LootBoxNotifierManager m_LootBoxNotification;

	private WeaponPart m_TempWeaponPart;

	public void TestingButtonCall(string Boxname)
	{
		GenerateRandomItem(GlobalDatabase.GetRandomLoot(Boxname));
	}

	public void GenerateRandomItem(int ItemCode)
	{
		gameObject.SetActive(true);
		m_LootBoxAnimation.gameObject.SetActive(true);
		m_LootBoxAnimation.SetTrigger("OpenBox");
		m_TempWeaponPart = new WeaponPart(ItemCode);
		m_LootBoxNotification.m_InventoryBindCode = GlobalWeaponData.AddWeaponPart(m_TempWeaponPart);
		Invoke("CallLootBox", 1);
		Invoke("CloseLootBox", 1);
	}

	public void CallLootBox()
	{
		m_LootBoxNotification.DisplayItem(m_TempWeaponPart);
	}

	public void CloseLootBox()
	{
		gameObject.SetActive(false);
		m_LootBoxAnimation.gameObject.SetActive(false);
	}
}
