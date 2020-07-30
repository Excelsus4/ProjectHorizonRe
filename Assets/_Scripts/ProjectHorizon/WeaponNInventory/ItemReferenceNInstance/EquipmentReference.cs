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

		public enum EquipmentVisualPart {
			Head,
			Thorax_Inner,	Thorax_Outer,
			Stomach,
			Shoulder_Left,	Shoulder_Right,
			UpperArm_Left,	UpperArm_Right,
			LowerArm_Left,	LowerArm_Right,
			UpperLeg_Left,	UpperLeg_Right,
			LowerLeg_Left,	LowerLeg_Right,
			Foot_Left,		Foot_Right
		}

		public struct EquipmentVisual {
			public EquipmentVisualPart Part;
			public Sprite Visual;
			public int Priority;
		}

		public string m_EquipmentName;
		public Sprite m_Icon;
		public List<EquipmentVisual> m_Visuals;

		public override string GetName() {
			return "Item_Equipment_" + m_EquipmentName;
		}

		public override Sprite GetSprite() {
			return m_Icon;
		}
	}
}