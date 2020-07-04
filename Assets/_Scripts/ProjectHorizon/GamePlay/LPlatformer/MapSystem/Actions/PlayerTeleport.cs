using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer.MapSystem.Actions {
	[CreateAssetMenu(fileName = "New Action", menuName = "ProjectHorizon/LPlatformer/Action/PlayerTeleport")]
	public class PlayerTeleport : ActionComponent {
		public Vector2 CertainPosition;

		public override void Activate() {
			GameObject.Find("PlayerCharacter").transform.localPosition = CertainPosition;
		}
	}
}