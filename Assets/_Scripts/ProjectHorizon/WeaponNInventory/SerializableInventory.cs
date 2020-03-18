using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	[Serializable]
	public class SerializableInventory {
		public SerializableItem[] serializableItems;

		public SerializableInventory(InventoryData data) {
			serializableItems = new SerializableItem[data.inventoryItems.Count];
			for(int idx = 0; idx < serializableItems.Length; idx++) {
				serializableItems[idx] = new SerializableItem(data.inventoryItems[idx]);
			}
		}

		public SerializableInventory(UserHandWeaponData data) {
			serializableItems = new SerializableItem[data.weapon.weaponModList.Count];
			for (int idx = 0; idx < serializableItems.Length; idx++) {
				serializableItems[idx] = new SerializableItem(data.weapon.weaponModList[idx]);
			}
		}
	}
}