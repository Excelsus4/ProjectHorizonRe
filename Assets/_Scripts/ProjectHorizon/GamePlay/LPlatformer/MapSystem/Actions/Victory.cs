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
			Debug.Log("Victory!");
			GameObject.Find("Victory_Screen").GetComponent<SimpleUIOnNOff>().Activate();
		}
	}
}