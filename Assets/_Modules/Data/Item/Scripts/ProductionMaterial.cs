using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	[CreateAssetMenu(fileName = "New Resource", menuName = "ProjectHorizon/Resource/ResourceReference")]
	public class ProductionMaterial : ItemReference {
		public string m_ResourceName;
		public Sprite m_Visuals;

		public override string GetName() {
			return "Item_Resource_" + m_ResourceName;
		}

		public override Sprite GetSprite() {
			return m_Visuals;
		}
	}
}