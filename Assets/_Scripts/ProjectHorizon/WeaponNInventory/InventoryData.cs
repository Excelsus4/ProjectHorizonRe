using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.Modules.SynchronizedSaver;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using com.meiguofandian.Modules.ObserverPattern;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
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
		private List<IDataUpdateCallback> observers;

		public InventoryData() {
			inventoryItems = new List<InventoryItem>();
			observers = new List<IDataUpdateCallback>();
			saveID = "inventory";
			SynchronizeSaveData(SynchronizeType.Load);
		}

		private void NotifyObservers() {
			foreach (IDataUpdateCallback observer in observers) {
				observer.OnDataUpdate("InventoryData");
			}
		}

		public void AddItemToInventory(InventoryItem[] item) {
			foreach(InventoryItem element in item)
				inventoryItems.Add(element);
			SynchronizeSaveData(SynchronizeType.Save);
			NotifyObservers();
		}

		public void RemoveItemFromInventory(int index) {
			inventoryItems.RemoveAt(index);
			SynchronizeSaveData(SynchronizeType.Save);
			NotifyObservers();
		}

		public void GenerateItemType() {

		}

		public void SortInventory() {

		}

		public void RegisterObserver(IDataUpdateCallback observer) {
			Debug.Log("observer registered");
			observers.Add(observer);
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

			// Create a reference book and using the Reference string, create new item instances
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