using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.synchronizedSaver;

namespace com.meiguofandian.projectHorizon.inventory {
	public class InventoryData : SynchronizedSave {
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
			saveID = "Inventory";
			singleton.SynchronizeSaveData(SynchronizeType.Load);
		}

		public void AddItemToInventory(InventoryItem item) {
			SynchronizeSaveData(SynchronizeType.Load);
			inventoryItems.Add(item);
			SynchronizeSaveData(SynchronizeType.Save);
		}

		public void GenerateItemType() {

		}

		public void SortInventory() {

		}

		protected override void LoadItem(string saveData) {
		}
	}
}