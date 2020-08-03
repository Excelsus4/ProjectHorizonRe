using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.Shooting {
	public class AnimationCallback : MonoBehaviour {
		public VoxelInputControl legacyInput;

		public void ReloadComplete() {
			legacyInput.ReloadComplete();
		}
	}
}