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
		
		public WeaponMod.ModPart GetStatus(WeaponMod.Status which) {
			WeaponMod.ModPart status = 0x0;
			switch (which) {
			case WeaponMod.Status.Unlocked:
				status |= WeaponMod.ModPart.Receiver;
				foreach (ModInstance mod in weaponModList) 
					status |= mod.m_Reference.m_Unlocks;
				break;
			case WeaponMod.Status.Locked:
				foreach (ModInstance mod in weaponModList)
					status |= mod.m_Reference.m_Locks;
				break;
			}
			return status;
		}

		public ModInstance GetModInstance(WeaponMod.ModPart target) {
			foreach(ModInstance mod in weaponModList) {
				if (( mod.m_Reference.m_Mainly & target ) > 0)
					return mod;
			}
			return null;
		}
	}
}