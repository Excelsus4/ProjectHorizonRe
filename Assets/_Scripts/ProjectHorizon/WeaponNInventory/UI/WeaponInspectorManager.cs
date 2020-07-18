using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	public class WeaponInspectorManager : MonoBehaviour {
		public WeaponRenderer WeaponRenderer;
		public WeaponOverlayManager IconRenderer;
		public Canvas Underlay;

		private void Start() {
			UpdateInspector();
		}

		public void UpdateInspector() {
			WeaponRenderer.Render();
			
			IconRenderer.Render();
		}
	}
}