using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer.MapSystem {
	public abstract class ActionComponent:ScriptableObject {
		public abstract void Activate();
	}
}