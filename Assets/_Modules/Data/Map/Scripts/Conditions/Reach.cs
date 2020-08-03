using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer.MapSystem.Conditions {
	[CreateAssetMenu(fileName = "New Condition", menuName = "ProjectHorizon/LPlatformer/Condition/Reach")]
	public class Reach : ConditionComponent {
		public Rect CertainRange;
		public override bool Check(Footprint footprint) {
			return CertainRange.Contains(footprint.PlayerPosition);
		}
	}
}