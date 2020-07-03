using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	[CreateAssetMenu(fileName = "New Resource Instance", menuName = "ProjectHorizon/Resource/ResourceInstance")]
	public class MaterialInstance : InventoryItem {
		public ProductionMaterial m_Reference;
		public int m_Amount;

		public override string GetReferenceName() {
			return m_Reference.GetName();
		}
	}
}