﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	[CreateAssetMenu(fileName = "New Equipment Instance", menuName = "ProjectHorizon/Equipment/Instance")]
	public class EquipmentInstance : InventoryItem {
		public EquipmentReference m_Reference;
		public int[] m_Upgrades;

		public override int[] GetInstanceData() {
			return m_Upgrades;
		}

		public override ItemReference GetReference() {
			return m_Reference;
		}

		public override string GetReferenceName() {
			return m_Reference.GetName();
		}

		public override void SetInstanceData(int[] data) {
			m_Upgrades = new int[UpgradeInterpreter.UpgradeLength];
			for (int idx = 0; idx < m_Upgrades.Length; idx++) {
				if (data == null) {
					m_Upgrades[idx] = 0;
				} else if (idx < data.Length) {
					m_Upgrades[idx] = data[idx];
				} else {
					m_Upgrades[idx] = 0;
				}
			}
		}

		public override void SetReference(ItemReference reference) {
			this.m_Reference = reference as EquipmentReference;
		}
	}
}