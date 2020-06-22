using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer {
	public class MapLiner : MonoBehaviour {
		public bool isTest;
		public MapData testMapData;
		public GameObject testLiners;
		public Material[] testMaterials = new Material[MapData.COMPONENT_TYPE_SIZE];
		public string[] LayerName = new string[MapData.COMPONENT_TYPE_SIZE];
		private int[] LineLayers = new int[MapData.COMPONENT_TYPE_SIZE];

		// Start is called before the first frame update
		void Start() {
			for(int idx = 0; idx < MapData.COMPONENT_TYPE_SIZE; idx++) {
				LineLayers[idx] = LayerMask.NameToLayer(LayerName[idx]);
			}

			if (UI.ScenarioSelector.ScenarioSelector.loadedMap) {
				testMapData = UI.ScenarioSelector.ScenarioSelector.loadedMap;
			}

			if (isTest) {
				foreach(MapData.MapComponent component in testMapData.Components) {
					GameObject instantiatedObject = Instantiate(testLiners, transform);
					LineRenderer lr = instantiatedObject.GetComponent<LineRenderer>();
					EdgeCollider2D ec = instantiatedObject.GetComponent<EdgeCollider2D>();

					instantiatedObject.layer = LineLayers[(int)component.CType];
					lr.material = testMaterials[(int)component.CType];
					lr.positionCount =component.Points.Length;
					ec.points = component.Points;

					for(int idx = 0; idx < component.Points.Length; idx++) {
						lr.SetPosition(idx, component.Points[idx]);
					}
				}
			}
		}

		// Update is called once per frame
		void Update() {

		}
	}
}
