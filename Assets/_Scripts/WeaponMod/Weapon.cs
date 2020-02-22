using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.weaponMod {
	public class Weapon {
		public List<WeaponMod> weaponModList = new List<WeaponMod>();
		public Weapon CreateNewWeapon(WeaponMod receiver) {
			// An object of weapon only get created by receiver.
			if(receiver.m_requirementInformation[(int)WeaponMod.ReqInfo.Mainly] == (System.UInt64)WeaponMod.ModPart.Receiver) {
				Weapon newWeapon = new Weapon();
				newWeapon.weaponModList.Add(receiver);
				return newWeapon;
			} else
				return null;
		}
	}
}