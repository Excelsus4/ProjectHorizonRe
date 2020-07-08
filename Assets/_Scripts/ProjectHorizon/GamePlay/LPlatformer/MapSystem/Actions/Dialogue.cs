using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer.MapSystem.Actions {
	[CreateAssetMenu(fileName = "New Action", menuName = "ProjectHorizon/LPlatformer/Action/Dialogue")]
	public class Dialogue : ActionComponent {
		public string CharacterName;
		public string Speech;

		public override void Activate() {
			Debug.Log(CharacterName + " said : " + Speech);
		}
	}
}