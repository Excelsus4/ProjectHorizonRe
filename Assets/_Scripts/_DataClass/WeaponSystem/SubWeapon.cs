using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeapon : Weapon
{
	public SubWeapon()
	{
		//무기 필요종류 정의
		this.m_partRequired = new WeaponPart.PartType[3];
		this.m_partRequired[0] = WeaponPart.PartType.Pistol;
		this.m_partRequired[1] = WeaponPart.PartType.Muzzle;
		this.m_partRequired[2] = WeaponPart.PartType.Sight;

		for (int idi = 0; idi < m_partRequired.Length; idi++)
			this.m_WeaponPartInventory.Add(null);

		CreateBasicState();

		RecalculateStats();
	}

	protected override void CreateBasicState()
	{
		ChangeWeaponPart(GlobalDatabase.BasicPartCreator(12));
	}
}
