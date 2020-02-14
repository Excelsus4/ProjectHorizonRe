using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bayonet : Weapon
{
	public Bayonet()
	{
		//무기 필요종류 정의
		this.m_partRequired = new WeaponPart.PartType[2];
		this.m_partRequired[0] = WeaponPart.PartType.Blade;
		this.m_partRequired[1] = WeaponPart.PartType.Handle;

		for (int idi = 0; idi < m_partRequired.Length; idi++)
			this.m_WeaponPartInventory.Add(null);

		CreateBasicState();

		RecalculateStats();
	}

	protected override void CreateBasicState()
	{
		ChangeWeaponPart(GlobalDatabase.BasicPartCreator(14));
		ChangeWeaponPart(GlobalDatabase.BasicPartCreator(15));
		//Some Basic Blade
	}
}
