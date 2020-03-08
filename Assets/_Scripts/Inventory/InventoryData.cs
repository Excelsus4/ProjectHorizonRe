using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.synchronizedSaver;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
			saveID = "inventory";
			singleton.SynchronizeSaveData(SynchronizeType.Load);
		}

		public void AddItemToInventory(InventoryItem item) {
			inventoryItems.Add(item);
			SynchronizeSaveData(SynchronizeType.Save);
		}

		public void GenerateItemType() {

		}

		public void SortInventory() {

		}

		protected override void SaveItem(Stream stream) {
			BinaryFormatter formatter = new BinaryFormatter();
			SerializableInventory data = new SerializableInventory(this);
			formatter.Serialize(stream, data);
		}

		protected override void LoadItem(Stream stream) {
			BinaryFormatter formatter = new BinaryFormatter();
			SerializableInventory data = formatter.Deserialize(stream) as SerializableInventory;

			// Update Inventory
			inventoryItems.Clear();

			// TODO: Create a reference book and using the Reference string, create new item instances
			foreach(SerializableItem itemData in data.serializableItems) {
				inventoryItems.Add(InventoryItem.CreateByReferenceName(itemData.item_name));
			}

			// Note that stream will be closed from the called parent 
		}

		protected override void LoadItem() {
			// For Inventory, there is nothing to do.
			// Maybe if there needs to be default items for newbs, add it here.
			// do you want some Hardtack?
			return;
		}
	}
}