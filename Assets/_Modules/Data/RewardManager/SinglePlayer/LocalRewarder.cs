using System.Collections;
using System.Collections.Generic;
using com.meiguofandian.ProjectHorizon.WeaponNInventory;
using UnityEngine;
using com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer;

	namespace com.meiguofandian.ProjectHorizon.RewardManager.SinglePlayer {
	public class LocalRewarder : RewardManager {
		private MapData.DropElement[] dropTable;

		private void Start() {
			dropTable = GameObject.Find("MapLiner").GetComponent<MapLiner>().testMapData.DropTable;
		}

		public override InventoryItem[] GetReward() {
			List<InventoryItem> tempList = new List<InventoryItem>();
			foreach(MapData.DropElement dropChance in dropTable) {
				if(dropChance.DropChance > Random.Range(0f, 1f)) {
					tempList.Add(InventoryItem.CreateByInstance(dropChance.ItemInstance, Random.Range(dropChance.MinAmount, dropChance.MaxAmount + 1)));
				}
			}
			return tempList.ToArray();
		}
	}
}