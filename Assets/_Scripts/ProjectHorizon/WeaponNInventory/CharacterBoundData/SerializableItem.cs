using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	[Serializable]
	public class SerializableItem {
		public string item_name;
		public int[] item_data;

		public SerializableItem(InventoryItem mod) {
			item_name = mod.GetReferenceName();
			item_data = mod.GetInstanceData();
		}
	}
}