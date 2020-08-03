using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer.MapSystem.Actions {
	[CreateAssetMenu(fileName = "New Action", menuName = "ProjectHorizon/LPlatformer/Action/CreateObject")]
	public class CreateObject : ActionComponent {
		public Vector2 CertainPosition;
		public GameObject CertainObject;

		public override void Activate() {
			Instantiate(CertainObject, CertainPosition, Quaternion.identity);
		}
	}
}