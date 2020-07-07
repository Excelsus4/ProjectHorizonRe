using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.ProjectHorizon.WeaponNInventory;

namespace com.meiguofandian.ProjectHorizon.RewardManager {
	public abstract class RewardManager : MonoBehaviour {
		public abstract InventoryItem[] GetReward();
	}
}