using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDisplayManager : MonoBehaviour , IPointerClickHandler{
	[HideInInspector]
	public int InventoryCode;

	public WeaponPart BoundWeapon;
	public UnityEngine.UI.Image m_Frame;
	public UnityEngine.UI.Image m_Icon;
	
	public void SetPart(WeaponPart reference)
	{
		BoundWeapon = reference;
		if (reference == null)
		{
			m_Frame.sprite = null;
			m_Icon.sprite = null;
			m_Frame.gameObject.SetActive(false);
			m_Icon.gameObject.SetActive(false);
		}
		else
		{
			m_Frame.gameObject.SetActive(true);
			m_Icon.gameObject.SetActive(true);
			m_Frame.sprite = GlobalDatabase.GetWeaponIconSprite((int)reference.P_PartGrade, 0);
			m_Icon.sprite = GlobalDatabase.GetWeaponIconSprite((int)reference.P_PartType, 1);
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (LootBoxNotifierManager.g_Notifier != null)
		{
			LootBoxNotifierManager.g_Notifier.DisplayItem(BoundWeapon);
			LootBoxNotifierManager.g_Notifier.m_InventoryBindCode = InventoryCode;
		}
	}
}
