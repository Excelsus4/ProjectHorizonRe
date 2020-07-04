﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer.MapSystem.Actions {
	[Serializable]
	public class PlayerTeleport : ActionComponent {
		Vector2 CertainPosition;

		public override void Activate() {
			GameObject.Find("PlayerCharacter").transform.localPosition = CertainPosition;
		}
	}
}