using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryNewManager : MonoBehaviour {
	public GameObject m_ItemDisplayPrefab;
	[HideInInspector]
	public GameObject[] m_ItemDisplay;

	private void Awake()
	{
		m_ItemDisplay = new GameObject[GlobalWeaponData.g_Inventory.Length];
		for(int idi = 0; idi< GlobalWeaponData.g_Inventory.Length; idi++)
		{
			m_ItemDisplay[idi] = Instantiate(m_ItemDisplayPrefab, transform);
			m_ItemDisplay[idi].GetComponent<ItemDisplayManager>().InventoryCode = idi;
			m_ItemDisplay[idi].transform.localPosition = new Vector3(-148 + 37 * (idi % 4), 208 - 37 * (idi / 4), 0);
		}
	}

	public void Refresh()
	{
		for (int idi = 0; idi < GlobalWeaponData.g_Inventory.Length; idi++)
		{
			m_ItemDisplay[idi].GetComponent<ItemDisplayManager>().SetPart(GlobalWeaponData.g_Inventory[idi]);
		}
	}
}
