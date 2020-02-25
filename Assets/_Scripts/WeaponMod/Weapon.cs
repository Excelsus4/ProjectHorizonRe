using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.weaponMod {
	[CreateAssetMenu(fileName = "New Weapon", menuName = "ProjectHorizon/Weapon/Weapon")]
	public class Weapon:ScriptableObject {
		public List<ModInstance> weaponModList = new List<ModInstance>();

		public Weapon CreateNewWeapon(ModInstance receiver) {
			// An object of weapon only get created by receiver.
			if(receiver.m_Reference.m_Mainly == WeaponMod.ModPart.Receiver) {
				Weapon newWeapon = new Weapon();
				newWeapon.weaponModList.Add(receiver);
				return newWeapon;
			} else
				return null;
		}

		/// <summary>
		/// Gets the weapon's modding status.
		/// </summary>
		/// <param name="WhichOne">Unlocks or Locks in string</param>
		/// <returns></returns>
		public WeaponMod.ModPart GetStatus(string WhichOne) {
			WeaponMod.ModPart status = 0x0;
			switch (WhichOne) {
			case "Unlocks":
				status |= WeaponMod.ModPart.Receiver;
				foreach (ModInstance mod in weaponModList) 
					status |= mod.m_Reference.m_Unlocks;
					break;
			case "Locks":
				foreach (ModInstance mod in weaponModList)
					status |= mod.m_Reference.m_Locks;
				break;
			default:
				throw new Exception("ITS EITHER Unlocks or Locks");
			}
			return status;
		}
	}
}