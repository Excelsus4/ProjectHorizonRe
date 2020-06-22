using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer;
using UnityEngine.UI;

namespace com.meiguofandian.ProjectHorizon.UI.ScenarioSelector {
	public class MapInfoViewer : MonoBehaviour {
		public Text TitleView;
		public Text DescriptionView;

		public void ViewMap(MapData mapData) {
			TitleView.text = mapData.Title;
			DescriptionView.text = mapData.Description;
		}

		public void ConfirmGame() {
			UnityEngine.SceneManagement.SceneManager.LoadScene("__Scene/PlatformerBattle");
		}
	}
}