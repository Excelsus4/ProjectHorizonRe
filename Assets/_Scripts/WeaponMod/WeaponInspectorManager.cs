using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.weaponMod;

namespace com.meiguofandian.projectHorizon.manager {
	public class WeaponInspectorManager : MonoBehaviour {
		public weaponRenderer.WeaponRenderer WeaponRenderer;
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