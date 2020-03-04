using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.weaponMod {
	[CreateAssetMenu(fileName = "New Mod Instance", menuName = "ProjectHorizon/Weapon/ModInstance")]
	public class ModInstance : ScriptableObject {
		public UInt64 m_ItemCode;
		public WeaponMod m_Reference;

		public static UInt64 GenerateItemCode() {
			return 0;
		}

		public static ModInstance CreateInstance(WeaponMod reference) {
			if (reference == null)
				return null;
			else {
				return new ModInstance {
					m_ItemCode = GenerateItemCode(),
					m_Reference = reference
				};
			}
		}
	}
}