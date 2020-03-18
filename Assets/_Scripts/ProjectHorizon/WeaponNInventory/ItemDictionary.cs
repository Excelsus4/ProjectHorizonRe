using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	public static class ItemDictionary {
		public static Dictionary<string, ItemReference> dictionary = new Dictionary<string, ItemReference>();
		public static ModInstance[] defaultWeapon;
	}
}