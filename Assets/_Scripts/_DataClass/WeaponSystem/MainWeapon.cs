using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWeapon : Weapon
{
	public MainWeapon()
	{
		//무기 필요종류 정의
		this.m_partRequired = new WeaponPart.PartType[6];
		this.m_partRequired[0] = WeaponPart.PartType.Receiver;
		this.m_partRequired[1] = WeaponPart.PartType.Stock;
		this.m_partRequired[2] = WeaponPart.PartType.Magazine;
		this.m_partRequired[3] = WeaponPart.PartType.Sight;
		this.m_partRequired[4] = WeaponPart.PartType.Barrel;
		this.m_partRequired[5] = WeaponPart.PartType.Muzzle;

		for (int idi = 0; idi < m_partRequired.Length; idi++)
			this.m_WeaponPartInventory.Add(null);

		CreateBasicState();

		RecalculateStats();
	}

	protected override void CreateBasicState()
	{
		//Stock
		ChangeWeaponPart(GlobalDatabase.BasicPartCreator(5));
		//Receiver
		ChangeWeaponPart(GlobalDatabase.BasicPartCreator(6));
		//Magazine
		ChangeWeaponPart(GlobalDatabase.BasicPartCreator(7));
		//Sight
		ChangeWeaponPart(GlobalDatabase.BasicPartCreator(8));
		//Barrel
		ChangeWeaponPart(GlobalDatabase.BasicPartCreator(9));
		//Muzzle
		ChangeWeaponPart(GlobalDatabase.BasicPartCreator(11));
		//Muzzle
	}
}
