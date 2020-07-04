using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer.MapSystem.Actions {
	[Serializable]
	public class CreateObject : ActionComponent {
		public Vector2 CertainPosition;
		public GameObject CertainObject;

		public override void Activate() {
			Instantiate(CertainObject, CertainPosition, Quaternion.identity);
		}
	}
}