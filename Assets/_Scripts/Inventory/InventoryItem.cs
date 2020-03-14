using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.weaponMod;

namespace com.meiguofandian.projectHorizon.inventory { 
	public abstract class InventoryItem : ScriptableObject {
		public abstract string GetReferenceName();

		public static InventoryItem CreateByReferenceName(string referenceName) {
			// Temporary code. need to add other types when other types of items are implemented
			if (ItemDictionary.dictionary.ContainsKey(referenceName)) {
				ModInstance instance = ScriptableObject.CreateInstance<ModInstance>();
				instance.m_Reference = (WeaponMod)ItemDictionary.dictionary[referenceName];
				return instance;
			} else {
				return null;
			}
		}
	}
}