using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer {
	public class MapLiner : MonoBehaviour {
		public bool isTest;
		public MapData testMapData;
		public GameObject testLiners;
		public Material[] testMaterials = new Material[MapData.COMPONENT_TYPE_SIZE];

		// Start is called before the first frame update
		void Start() {
			if (isTest) {
				foreach(MapData.MapComponent component in testMapData.Components) {
					GameObject instantiatedObject = Instantiate(testLiners, transform);
					LineRenderer lr = instantiatedObject.GetComponent<LineRenderer>();
					EdgeCollider2D ec = instantiatedObject.GetComponent<EdgeCollider2D>();

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
