using UnityEngine;
using UnityEditor;
using com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer;

[CustomEditor(typeof(MapLiner))]
public class MapLinerEditor : Editor {
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();

		MapLiner mapLiner = (MapLiner)target;
		if (GUILayout.Button("Reload Map")) {
			mapLiner.LoadMapComponent();
		}
	}
}
