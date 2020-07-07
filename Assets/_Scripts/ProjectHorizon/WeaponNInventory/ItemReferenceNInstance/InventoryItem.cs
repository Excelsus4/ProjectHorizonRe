using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	public abstract class InventoryItem : ScriptableObject {
		public abstract string GetReferenceName();
		public abstract ItemReference GetReference();
		public abstract int[] GetInstanceData();
		public abstract void SetReference(ItemReference reference);
		public abstract void SetInstanceData(int[] data);

		public static InventoryItem CreateByReferenceName(string referenceName, int[] data) {
			if (ItemDictionary.dictionary.ContainsKey(referenceName)) {
				ItemReference reference = ItemDictionary.dictionary[referenceName];
				switch (reference) {
				case WeaponMod mod:
					return CreateByReference(mod, data);
				case ProductionMaterial res:
					return CreateByReference(res, data);
				}
			}
			return null;
		}

		public static ModInstance CreateByReference(WeaponMod reference, int[] data) {
			ModInstance instance = CreateInstance<ModInstance>();
			instance.m_Reference = reference;
			instance.SetInstanceData(data);
			return instance;
		}

		public static MaterialInstance CreateByReference(ProductionMaterial reference, int[] data) {
			MaterialInstance instance = CreateInstance<MaterialInstance>();
			instance.m_Reference = reference;
			instance.SetInstanceData(data);
			return instance;
		}

		public static InventoryItem CreateByInstance(InventoryItem Instance, int Data) {
			InventoryItem newItem = null;
			switch (Instance) {
			case ModInstance mod:
				newItem = CreateInstance<ModInstance>();
				newItem.SetReference(Instance.GetReference());
				newItem.SetInstanceData(Instance.GetInstanceData());
				( (ModInstance)newItem ).m_Upgrades[0] += Data;
				break;
			case MaterialInstance res:
				newItem = CreateInstance<MaterialInstance>();
				newItem.SetReference(Instance.GetReference());
				newItem.SetInstanceData(Instance.GetInstanceData());
				( (MaterialInstance)newItem ).m_Amount *= Data;
				break;
			}

			return newItem;
		}
	}
}