using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	public class DataLoader : MonoBehaviour {
		public ItemReference[] itemReferences;
		public ModInstance[] defaultWeaponData;

		private void Awake() {
			if (!ItemDictionary.isLoaded) {
				foreach (ItemReference item in itemReferences) {
					ItemDictionary.dictionary.Add(item.GetName(), item);
				}
				ItemDictionary.defaultWeapon = defaultWeaponData;
				ItemDictionary.isLoaded = true;
			}
		}
	}
}