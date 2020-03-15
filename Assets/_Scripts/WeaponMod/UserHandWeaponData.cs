using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.synchronizedSaver;
using com.meiguofandian.core;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using com.meiguofandian.weaponMod;

namespace com.meiguofandian.projectHorizon.inventory {
	public class UserHandWeaponData : SynchronizedSave {
		private static UserHandWeaponData singleton;

		public static UserHandWeaponData getSingleton() {
			if (singleton != null)
				return singleton;
			else
				return createSingleton();
		}

		private static UserHandWeaponData createSingleton() {
			singleton = new UserHandWeaponData();
			return singleton;
		}

		public weaponMod.Weapon weapon;
		private List<IDataUpdateCallback> observers;

		public UserHandWeaponData() {
			observers = new List<IDataUpdateCallback>();
			saveID = "weapon_hand";
			SynchronizeSaveData(SynchronizeType.Load);
		}

		private void NotifyObservers() {
			foreach (IDataUpdateCallback observer in observers) {
				observer.OnDataUpdate();
			}
		}

		public List<ModInstance> AddModToInventory(ModInstance[] mods) {
			List<ModInstance> used = new List<ModInstance>();
			foreach (ModInstance element in mods) {
				if (weapon.AddMod(element))
					used.Add(element);
			}
			SynchronizeSaveData(SynchronizeType.Save);
			NotifyObservers();
			return used;
		}

		public void RemoveModFromWeapon(WeaponMod.ModPart weaponPart) {
			List<ModInstance> returned = weapon.RemoveMod(weaponPart);
			SynchronizeSaveData(SynchronizeType.Save);
			NotifyObservers();
			InventoryData.getSingleton().AddItemToInventory(returned.ToArray());
		}

		public void GenerateItemType() {

		}

		public void SortInventory() {

		}

		public void RegisterObserver(IDataUpdateCallback observer) {
			Debug.Log("observer registered");
			observers.Add(observer);
			observer.OnDataUpdate();
		}

		protected override void SaveItem(Stream stream) {
			BinaryFormatter formatter = new BinaryFormatter();
			SerializableInventory data = new SerializableInventory(this);
			formatter.Serialize(stream, data);
		}

		protected override void LoadItem(Stream stream) {
			BinaryFormatter formatter = new BinaryFormatter();

			// Temporary For now
			//LoadItem();


			SerializableInventory data = formatter.Deserialize(stream) as SerializableInventory;

			// Update Inventory
			weapon = new weaponMod.Weapon();
			//inventoryItems.Clear();

			// Create a reference book and using the Reference string, create new item instances
			foreach (SerializableItem itemData in data.serializableItems) {
				weapon.AddMod(InventoryItem.CreateByReferenceName(itemData.item_name) as ModInstance);
			}

			// Note that stream will be closed from the called parent 
		}

		protected override void LoadItem() {
			// Load A Default Weapon
			weapon = new weaponMod.Weapon();
			foreach(ModInstance element in ItemDictionary.defaultWeapon) {
				weapon.AddMod(element);
			}
		}
	}
}