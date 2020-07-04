using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer.MapSystem {
	[Serializable]
	public class Trigger {
		public ConditionComponent Condition;
		public ActionComponent Action;
	}
}