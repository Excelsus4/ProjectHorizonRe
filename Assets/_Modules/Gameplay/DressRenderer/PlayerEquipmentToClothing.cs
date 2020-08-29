using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.Modules.ObserverPattern;
using com.meiguofandian.ProjectHorizon.WeaponNInventory;

namespace com.meiguofandian.ProjectHorizon.Clothing {
	public class PlayerEquipmentToClothing : MonoBehaviour, IDataUpdateCallback {
		public EquipmentInstance[] Equipments;
		private Body bodySingleton;

		public void OnDataUpdate(string data) {
			Equipments = bodySingleton.slots.ToArray();
			VisualizeEquipment();
		}

		public void Start() {
			bodySingleton = Body.getSingleton();
			bodySingleton.RegisterObserver(this);
		}

		public void VisualizeEquipment() {
			HumanoidDresser dresser = GetComponentInChildren<HumanoidDresser>();
			dresser.ClearVisuals();
			// TODO: Unpack equipments' visual components HERE
			foreach (WeaponNInventory.EquipmentInstance equipment in Equipments) {
				dresser.m_Visuals.AddRange(equipment.m_Reference.m_Visuals);
			}
			dresser.Dress();
		}
	}
}