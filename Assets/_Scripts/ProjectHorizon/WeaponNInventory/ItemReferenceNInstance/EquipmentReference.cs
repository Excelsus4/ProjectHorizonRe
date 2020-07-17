using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	[CreateAssetMenu(fileName = "New Equipment", menuName = "ProjectHorizon/Equipment/Reference")]
	public class EquipmentReference : ItemReference { 
		public override string GetName() {
			throw new System.NotImplementedException();
		}

		public override Sprite GetSprite() {
			throw new System.NotImplementedException();
		}
	}
}