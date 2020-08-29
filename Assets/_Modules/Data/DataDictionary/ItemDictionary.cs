using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	public static class ItemDictionary {
		public static bool isLoaded = false;
		public static Dictionary<string, ItemReference> dictionary = new Dictionary<string, ItemReference>();
		public static ModInstance[] defaultWeapon;
		public static EquipmentInstance[] defaultEquipment;
	}
}