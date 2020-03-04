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
			return GetStatus(weaponModList, which);
		}

		private WeaponMod.ModPart GetStatus(List<ModInstance> someWeapon, WeaponMod.Status which) {
			WeaponMod.ModPart status = 0x0;
			switch (which) {
			case WeaponMod.Status.Unlocked:
				status |= WeaponMod.ModPart.Receiver;
				foreach (ModInstance mod in someWeapon) 
					status |= mod.m_Reference.m_Unlocks;
				break;
			case WeaponMod.Status.Locked:
				foreach (ModInstance mod in someWeapon)
					status |= mod.m_Reference.m_Locks;
				break;
			case WeaponMod.Status.Requires:
				foreach (ModInstance mod in someWeapon)
					status |= mod.m_Reference.m_Requires;
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

		public bool CheckModAvailability(ModInstance modToAdd) {
			return CheckModAvailability(weaponModList, modToAdd);
		}

		private bool CheckModAvailability(List<ModInstance> modsAlready, ModInstance modToAdd) {
			if (( GetStatus(modsAlready, WeaponMod.Status.Unlocked) & ~GetStatus(modsAlready, WeaponMod.Status.Locked) & modToAdd.m_Reference.m_Requires ) > 0) {
				return true;
			} else {
				return false;
			}
		}

		/// <summary>
		/// This will try to remove a single mod and then validate the weapon and remove all linked mods.
		/// </summary>
		/// <param name="target">Give a single mod.</param>
		/// <returns>Mods that are removed, this include the target</returns>
		public List<ModInstance> RemoveMod(WeaponMod.ModPart target) {
			ModInstance removed = GetModInstance(target);
			if(removed != null) {
				weaponModList.Remove(removed);
				List<ModInstance> linkRemoved = ValidateModdingStatus();
				linkRemoved.Add(removed);
				return linkRemoved;
			}
			return null;
		}

		/// <summary>
		/// This will recalculate the whole weapon modding system and returns all non-usable mods
		/// Quite compute intense so should only used when necessary
		/// </summary>
		/// <returns>Returned List contains mods that are not valid in current status, return it to inventory</returns>
		public List<ModInstance> ValidateModdingStatus() {
			List<ModInstance> temporary = weaponModList;
			weaponModList = new List<ModInstance>();
			for(int idx = 0; idx < temporary.Count; idx++) {
				if(CheckModAvailability(weaponModList, temporary[idx])) {
					weaponModList.Add(temporary[idx]);
					temporary.RemoveAt(idx--);
				}
			}
			return temporary;
		}
	}
}