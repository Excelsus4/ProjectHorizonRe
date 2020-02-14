using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalWeaponData {
	public static Weapon g_CurrentWeapon;
	public static Weapon[] g_AllWeapon = new Weapon[4]; //Main Main Sub Bayo

	//INVENTORY DATA
	public static WeaponPart[] g_Inventory = new WeaponPart[64];    //MAX INVENTORY SIZE

	public static EquipmentManager EquipmentManagerCallback;
	public static List<WeaponRenderer> WeaponRendererCallback = new List<WeaponRenderer>();

	public static void GlobalRefresh()
	{
		for(int idi = 0; idi < g_AllWeapon.Length; idi++)
			g_AllWeapon[idi].RecalculateStats();
		if (EquipmentManagerCallback != null)
			EquipmentManagerCallback.Refresh();
		foreach (WeaponRenderer element in WeaponRendererCallback)
			element.UpdateToCurrent();
	}
	
	public static int AddWeaponPart(WeaponPart thisPart)
	{
		if (thisPart == null)
			return -1;

		for(int idi = 0; idi < g_Inventory.Length; idi++)
		{
			if (g_Inventory[idi] == null)
			{
				g_Inventory[idi] = thisPart;
				return idi;
			}
		}

		return -1;
	}

	public static WeaponPart GetWeaponPart(int InventoryCode)
	{
		return g_Inventory[InventoryCode];
	}

	public static void RemoveWeaponPart(int InventoryCode)
	{
		g_Inventory[InventoryCode] = null;
	}
}
