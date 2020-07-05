using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer.MapSystem {
	public abstract class ConditionComponent :ScriptableObject {
		public abstract bool Check(Footprint footprint);

		public class Footprint {
			public Vector2 PlayerPosition;
			public Dictionary<string, int> KillTable;

			public Footprint() {
				PlayerPosition = Vector2.zero;
				KillTable = new Dictionary<string, int>();
			}
		}
	}
}