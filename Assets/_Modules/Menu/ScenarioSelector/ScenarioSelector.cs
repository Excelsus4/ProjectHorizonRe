using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer;

namespace com.meiguofandian.ProjectHorizon.UI.ScenarioSelector {
	public class ScenarioSelector : MonoBehaviour {
		public static MapData loadedMap = null;
		public MapInfoViewer InfoViewer;
		public MapData[] ScenarioList;
		public void ScenarioSelection(int MapCode) {
			InfoViewer.gameObject.SetActive(true);
			loadedMap = ScenarioList[MapCode];
			InfoViewer.ViewMap(loadedMap);
		}
	}
}