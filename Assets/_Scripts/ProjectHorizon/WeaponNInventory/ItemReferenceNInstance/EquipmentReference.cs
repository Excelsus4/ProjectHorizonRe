using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	[CreateAssetMenu(fileName = "New Equipment", menuName = "ProjectHorizon/Equipment/Reference")]
	public class EquipmentReference : ItemReference {
		public enum EquipmentPart {
			Helmet,
			Body,
			Rig,
			Leggings,
			Gloves,
			Boots,
		}

		public string m_EquipmentName;
		public Sprite m_Icon;
		public List<Clothing.HumanoidDresser.EquipmentVisual> m_Visuals;

		public override string GetName() {
			return "Item_Equipment_" + m_EquipmentName;
		}

		public override Sprite GetSprite() {
			return m_Icon;
		}
	}
}