﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace com.meiguofandian.projectHorizon.inventory {
	[Serializable]
	public class SerializableInventory {
		public SerializableItem[] serializableItems;

		public SerializableInventory(InventoryData data) {
			serializableItems = new SerializableItem[data.inventoryItems.Count];
			for(int idx = 0; idx < serializableItems.Length; idx++) {
				serializableItems[idx] = new SerializableItem(data.inventoryItems[idx]);
			}
		}
	}
}