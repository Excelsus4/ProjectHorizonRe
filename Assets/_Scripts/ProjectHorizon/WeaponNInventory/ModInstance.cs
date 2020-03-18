using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	[CreateAssetMenu(fileName = "New Mod Instance", menuName = "ProjectHorizon/Weapon/ModInstance")]
	public class ModInstance : InventoryItem {
		public WeaponMod m_Reference;

		public static ModInstance CreateInstance(WeaponMod reference) {
			if (reference == null)
				return null;
			else {
				return new ModInstance {
					m_Reference = reference
				};
			}
		}

		public override string GetReferenceName() {
			return m_Reference.GetName();
		}
	}
}