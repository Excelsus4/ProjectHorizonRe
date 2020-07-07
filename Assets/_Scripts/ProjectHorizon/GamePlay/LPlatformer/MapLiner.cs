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
		private List<MapSystem.Trigger> triggers;
		private MapSystem.ConditionComponent.Footprint footprints;
		private Transform playerTransform;
		private int triggerInterval = 5;
		private int triggerCooltime = 1;

		// Start is called before the first frame update
		void Start() {
			for (int idx = 0; idx < MapData.COMPONENT_TYPE_SIZE; idx++) {
				LineLayers[idx] = LayerMask.NameToLayer(LayerName[idx]);
			}

			if (UI.ScenarioSelector.ScenarioSelector.loadedMap) {
				testMapData = UI.ScenarioSelector.ScenarioSelector.loadedMap;
			}

			foreach (MapData.MapComponent component in testMapData.Components) {
				GameObject instantiatedObject = Instantiate(testLiners, transform);
				EdgeCollider2D ec = instantiatedObject.GetComponent<EdgeCollider2D>();
				LineRenderer lr = instantiatedObject.GetComponent<LineRenderer>();
				instantiatedObject.layer = LineLayers[(int)component.Type];
				ec.points = component.Points;

				if (isTest) {
					lr.material = testMaterials[(int)component.Type];
					lr.positionCount = component.Points.Length;
					for (int idx = 0; idx < component.Points.Length; idx++) {
						lr.SetPosition(idx, component.Points[idx]);
					}
				}
			}

			triggers = new List<MapSystem.Trigger>();
			foreach (MapSystem.Trigger trigger in testMapData.Triggers) {
				triggers.Add(trigger);
			}
			footprints = new MapSystem.ConditionComponent.Footprint();
			playerTransform = GameObject.Find("PlayerCharacter").transform;
		}
		
		void Update() {
			triggerCooltime = ( triggerCooltime + 1 ) % triggerInterval;
			if(triggerCooltime==0)
				CheckTrigger();
		}

		private void CheckTrigger() {
			footprints.PlayerPosition = playerTransform.position;
			for (int idx = triggers.Count - 1; idx >= 0; idx--) {
				if (triggers[idx].Check(footprints)) {
					triggers[idx].Activate();
					triggers.RemoveAt(idx);
				}
			}
		}

		public void KillCount(string ShootableName) {
			print(ShootableName);
			if (footprints.KillTable.ContainsKey(ShootableName))
				footprints.KillTable[ShootableName]++;
			else
				footprints.KillTable.Add(ShootableName, 1);
		}

		public void ShutTrigger() {
			triggerInterval = int.MaxValue;
		}
	}
}
