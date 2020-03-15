using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.core;
using com.meiguofandian.weaponRenderer;
using com.meiguofandian.weaponMod;
using com.meiguofandian.projectHorizon.inventory;

namespace com.meiguofandian.projectHorizon.inventory {
	public class InventoryDisplay : MonoBehaviour, IDataUpdateCallback, IModIconButtonCallback {
		private UserHandWeaponData weaponData;
		private InventoryData data;

		private List<ModIconRenderer> listOfIconRenderers = new List<ModIconRenderer>();

		public GameObject m_IconObject;
		public Transform m_IconParent;
		public float[] m_IconSize = new float[2];
		public float[] m_IconGap = new float[2];
		public int m_IconColumn;

		private void Start() {
			weaponData = UserHandWeaponData.getSingleton();
			data = InventoryData.getSingleton();
			data.RegisterObserver(this);
			InventoryRender();
		}

		/// <summary>
		/// This will be called by inventory data when data is updated.
		/// </summary>
		public void OnDataUpdate() {
			InventoryRender();
		}

		public void InventoryRender() {
			int idx;
			for(idx = 0; idx < data.inventoryItems.Count; idx++) {
				if(listOfIconRenderers.Count <= idx) {
					// Not Enough Icons
					AssignIconRenderer(CreateNewIcon(idx), data.inventoryItems[idx]);
				} else {
					// Prepared Icons
					AssignIconRenderer(listOfIconRenderers[idx], data.inventoryItems[idx]);
				}
			}

			// Left over icons
			for(; idx < listOfIconRenderers.Count; idx++) {
				listOfIconRenderers[idx].IconAble(false);
			}
		}

		private ModIconRenderer CreateNewIcon(int index) {
			Vector3 IconOffset = m_IconParent.position;
			IconOffset.x += ( index % m_IconColumn ) * m_IconGap[0] + m_IconSize[0];
			IconOffset.y += ( index / m_IconColumn ) * m_IconGap[1] + m_IconSize[1];

			ModIconRenderer newRenderer = Instantiate(m_IconObject, IconOffset, Quaternion.identity, m_IconParent).GetComponent<ModIconRenderer>();
			newRenderer.callbackIndex = index;
			listOfIconRenderers.Add(newRenderer);
			return newRenderer;
		}

		private void AssignIconRenderer(ModIconRenderer iconRenderer,InventoryItem weaponMod) {
			iconRenderer.IconAble(true);
			iconRenderer.callbackManager = this;
			iconRenderer.target = weaponMod;
			iconRenderer.UpdateImage();
		}

		public void ModIconCallback(int IDX, InventoryItem part) {
			if (part is ModInstance mod) {
				ModInstance[] mods = new ModInstance[1];
				mods[0] = mod;
				if(weaponData.AddModToInventory(mods).Count > 0)
					data.RemoveItemFromInventory(IDX);
			} else {
				// Do whatever the item is suppose to do. probably an inspect window
			}
		}
	}
}