using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	[CreateAssetMenu(fileName = "New Equipment Instance", menuName = "ProjectHorizon/Equipment/Instance")]
	public class EquipmentInstance : InventoryItem {
		public override int[] GetInstanceData() {
			throw new System.NotImplementedException();
		}

		public override ItemReference GetReference() {
			throw new System.NotImplementedException();
		}

		public override string GetReferenceName() {
			throw new System.NotImplementedException();
		}

		public override void SetInstanceData(int[] data) {
			throw new System.NotImplementedException();
		}

		public override void SetReference(ItemReference reference) {
			throw new System.NotImplementedException();
		}
	}
}