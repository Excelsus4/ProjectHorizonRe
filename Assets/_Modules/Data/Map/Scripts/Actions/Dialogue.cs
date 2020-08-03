using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.Modules.SimpleUIOnNOff;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer.MapSystem.Actions {
	[CreateAssetMenu(fileName = "New Action", menuName = "ProjectHorizon/LPlatformer/Action/Dialogue")]
	public class Dialogue : ActionComponent {
		public string CharacterName;
		public string Speech;

		public override void Activate() {
			SimpleDialogueViewer target = GameObject.Find("SimpleDialogueViewer").GetComponent<SimpleDialogueViewer>();
			target.SetDialogue(CharacterName, Speech);
		}
	}
}