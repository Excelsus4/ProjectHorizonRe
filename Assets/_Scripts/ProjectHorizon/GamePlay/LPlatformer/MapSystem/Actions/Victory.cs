using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.ProjectHorizon.WeaponNInventory;
using com.meiguofandian.Modules.SimpleUIOnNOff;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer.MapSystem.Actions {
	[CreateAssetMenu(fileName = "New Action", menuName = "ProjectHorizon/LPlatformer/Action/Victory")]
	public class Victory : ActionComponent {
		public override void Activate() {
			GameObject victoryScreen = GameObject.Find("Victory_Screen");
			MapLiner liner = GameObject.Find("MapLiner").GetComponent<MapLiner>();
			victoryScreen.GetComponent<SimpleUIOnNOff>().Activate();
			liner.ShutTrigger();

			InventoryItem[] drops = victoryScreen.GetComponent<RewardManager.RewardManager>().GetReward();
			// 1. Display Rewards
			victoryScreen.GetComponent<LootBarManager>().PresentRewards(drops);
			// 2. Actually Give the Rewards
			InventoryData.getSingleton().AddItemToInventory(drops);
		}
	}
}