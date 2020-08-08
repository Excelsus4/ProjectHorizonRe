using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer.MapSystem.Actions {
	[CreateAssetMenu(fileName = "New Action", menuName = "ProjectHorizon/LPlatformer/Action/MultipleObject")]
	public class MultipleObject : ActionComponent {
		public Vector2[] CertainPosition;
		public GameObject CertainObject;

		public override void Activate() {
			foreach(Vector2 point in CertainPosition) {
				Instantiate(CertainObject, point, Quaternion.identity);
			}
		}
	}
}