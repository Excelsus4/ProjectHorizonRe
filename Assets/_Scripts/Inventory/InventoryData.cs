using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.projectHorizon.inventory {
	public class InventoryData {
		private static InventoryData singleton;

		public static InventoryData getSingleton() {
			if (singleton != null)
				return singleton;
			else
				return createSingleton();
		}

		private static InventoryData createSingleton() {
			singleton = new InventoryData();
			return singleton;
		}

		public List<InventoryItem> inventoryItems;

		public InventoryData() {
			inventoryItems = new List<InventoryItem>();
		}

		public void AddItemToInventory() {

		}

		public void GenerateItemType() {

		}

		public void SortInventory() {

		}
	}
}