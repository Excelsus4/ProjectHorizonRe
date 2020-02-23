using System.Collections;
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
	}
}