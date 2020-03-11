using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.weaponMod;
using com.meiguofandian.projectHorizon.manager;
using com.meiguofandian.projectHorizon.inventory;

namespace com.meiguofandian.weaponRenderer {
	public interface IModIconButtonCallback {
		void ModIconCallback(int IDX, InventoryItem part);
	}
}