using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer.MapSystem {
	[CreateAssetMenu(fileName = "New Trigger", menuName = "ProjectHorizon/LPlatformer/MapTrigger")]
	public class Trigger:ScriptableObject {
		public ConditionComponent Condition;
		public ActionComponent Action;
	}
}