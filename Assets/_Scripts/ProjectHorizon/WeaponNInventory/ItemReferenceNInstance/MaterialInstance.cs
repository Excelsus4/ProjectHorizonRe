using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	[CreateAssetMenu(fileName = "New Resource Instance", menuName = "ProjectHorizon/Resource/ResourceInstance")]
	public class MaterialInstance : InventoryItem {
		public ProductionMaterial m_Reference;
		public int m_Amount;

		public override int[] GetInstanceData() {
			return new int[1] { m_Amount };
		}

		public override void SetInstanceData(int[] data) {
			m_Amount = data[0];
		}

		public override string GetReferenceName() {
			return m_Reference.GetName();
		}

		public override ItemReference GetReference() {
			return m_Reference;
		}

		public override void SetReference(ItemReference reference) {
			this.m_Reference = reference as ProductionMaterial;
		}
	}
}