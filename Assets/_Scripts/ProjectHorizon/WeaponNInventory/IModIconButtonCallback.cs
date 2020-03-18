using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	public interface IModIconButtonCallback {
		void ModIconCallback(int IDX, InventoryItem part);
	}
}