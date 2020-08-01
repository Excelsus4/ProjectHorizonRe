using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.Clothing {
	public class PlayerEquipmentToClothing : MonoBehaviour {
		public List<WeaponNInventory.EquipmentInstance> Equipments;

		public void Start() {
			VisualizeEquipment();
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