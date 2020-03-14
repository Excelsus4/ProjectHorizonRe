using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.weaponMod;

namespace com.meiguofandian.projectHorizon.inventory {
	public static class ItemDictionary {
		public static Dictionary<string, ItemReference> dictionary = new Dictionary<string, ItemReference>();
		public static ModInstance[] defaultWeapon;
	}
}