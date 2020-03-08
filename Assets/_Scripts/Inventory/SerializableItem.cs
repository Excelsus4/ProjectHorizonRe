using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using com.meiguofandian.weaponMod;

namespace com.meiguofandian.projectHorizon.inventory {
	[Serializable]
	public class SerializableItem {
		public string item_name;

		public SerializableItem(InventoryItem mod) {
			item_name = mod.GetReferenceName();
		}
	}
}