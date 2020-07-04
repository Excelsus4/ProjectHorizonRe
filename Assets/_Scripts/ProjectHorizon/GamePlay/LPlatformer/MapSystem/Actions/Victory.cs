using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer.MapSystem.Actions {
	[Serializable]
	public class Victory : ActionComponent {
		public override void Activate() {
			Debug.Log("Victory!");
		}
	}
}