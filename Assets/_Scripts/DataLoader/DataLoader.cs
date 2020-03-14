using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.projectHorizon.inventory;
using com.meiguofandian.weaponMod;

	namespace com.meiguofandian.projectHorizon.dataLoader {
	public class DataLoader : MonoBehaviour {
		public ItemReference[] itemReferences;
		public ModInstance[] defaultWeaponData;

		private void Awake() {
			foreach(ItemReference item in itemReferences) {
				ItemDictionary.dictionary.Add(item.GetName(), item);
				Debug.Log(item.GetName());
			}
			ItemDictionary.defaultWeapon = defaultWeaponData;
		}
	}
}