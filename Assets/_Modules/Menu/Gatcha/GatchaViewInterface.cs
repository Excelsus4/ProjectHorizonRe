using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.ProjectHorizon.WeaponNInventory;

namespace com.meiguofandian.ProjectHorizon.Gatcha {
	public interface GatchaViewInterface{
		void DoGatcha(InventoryItem input, InventoryItem output);
	}
}