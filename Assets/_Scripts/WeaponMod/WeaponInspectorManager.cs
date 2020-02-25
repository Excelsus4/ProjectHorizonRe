using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.weaponMod;

namespace com.meiguofandian.projectHorizon.manager {
	public class WeaponInspectorManager : MonoBehaviour {
		public weaponMod.Weapon WeaponOnInspect;
		public weaponRenderer.WeaponRenderer WeaponRenderer;
		public Canvas Underlay;
		public Canvas Overlay;
		public GameObject ModIconPrefab;

		private void Start() {
			UpdateInspector();
		}

		public void UpdateInspector() {
			WeaponRenderer.m_WeaponToRender = WeaponOnInspect;
			WeaponRenderer.Render();

			UInt32 unlockFlag = (UInt32)WeaponOnInspect.GetStatus("Unlocks");
			int goo = 0;
			while(unlockFlag > 0) {
				if((unlockFlag & 0x1) == 0x1) {
					// TODO: CREATE ICON SLOT FOR EACH UNLOCKED PARTS!!!!
					Debug.Log((WeaponMod.ModPart)( 0x1 << goo ));
				}
				goo++;
				unlockFlag >>= 1;
			}
		}
	}
}