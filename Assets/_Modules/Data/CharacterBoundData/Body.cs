using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.Modules.SynchronizedSaver;
using System.IO;
using com.meiguofandian.Modules.ObserverPattern;
using System.Runtime.Serialization.Formatters.Binary;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	public class Body : SynchronizedSave {
		private static Body singleton;
		public static Body getSingleton() {
			if (singleton != null)
				return singleton;
			else
				return createSingleton();
		}
		private static Body createSingleton() {
			singleton = new Body();
			return singleton;
		}
		private List<IDataUpdateCallback> observers;
		public List<EquipmentInstance> slots;

		public Body() {
			slots = new List<EquipmentInstance>();
			observers = new List<IDataUpdateCallback>();
			saveID = "equipment";
			SynchronizeSaveData(SynchronizeType.Load);
		}

		private void NotifyObservers() {
			foreach (IDataUpdateCallback observer in observers) {
				observer.OnDataUpdate("EquipmentData");
			}
		}

		public void EquipEquipment(EquipmentInstance equipment) {
			//TODO: check the slot used by the equipment and replace that item
		}

		protected override void LoadItem(Stream stream) {
			BinaryFormatter formatter = new BinaryFormatter();

			SerializableInventory data = formatter.Deserialize(stream) as SerializableInventory;
			
			foreach(SerializableItem itemData in data.serializableItems) {
				slots.Add(InventoryItem.CreateByReferenceName(itemData.item_name, itemData.item_data) as EquipmentInstance);
			}
		}

		protected override void LoadItem() {
			// Load Default Outfit
			foreach(EquipmentInstance element in ItemDictionary.defaultEquipment) {
				slots.Add(element);
			}
		}

		protected override void SaveItem(Stream stream) {
			BinaryFormatter formatter = new BinaryFormatter();
			SerializableInventory data = new SerializableInventory(this);
			formatter.Serialize(stream, data);
		}

		public void RegisterObserver(IDataUpdateCallback observer) {
			observers.Add(observer);
			observer.OnDataUpdate("EquipmentData");
		}
	}
}