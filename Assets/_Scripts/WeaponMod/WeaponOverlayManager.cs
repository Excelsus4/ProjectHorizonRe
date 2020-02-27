﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.weaponMod;
using com.meiguofandian.weaponRenderer;

namespace com.meiguofandian.projectHorizon.manager {
	public class WeaponOverlayManager : MonoBehaviour {
		private List<ModIconRenderer> listOfIconRenderers = new List<ModIconRenderer>();
		public weaponMod.Weapon m_WeaponToRender;
		public GameObject m_IconObject;
		public Transform m_IconParent;

		public void Render() {
			UInt32 unlockFlag = (UInt32)m_WeaponToRender.GetStatus(WeaponMod.Status.Unlocked);
			UInt32 lockFlag = (UInt32)m_WeaponToRender.GetStatus(WeaponMod.Status.Locked);

			int idx_partFlag = 0;
			int idx_renderer = 0;
			WeaponMod.Status flag_status;

			while (unlockFlag > 0) {
				if (( unlockFlag & 0x1 ) == 0x1) {
					if (( lockFlag & 0x1 ) == 0x1)
						flag_status = WeaponMod.Status.Locked;
					else
						flag_status = WeaponMod.Status.Unlocked;
					if(listOfIconRenderers.Count > idx_renderer) {
						// IconRenderer is left, use whats exist
						AssignIconRenderer(listOfIconRenderers[idx_renderer], flag_status, null, (WeaponMod.ModPart)( 0x1 << idx_partFlag ));
					} else {
						// Not enough Iconrenderer, create more and assign new
						AssignIconRenderer(CreateNewIcon(idx_renderer), flag_status, null, (WeaponMod.ModPart)(0x1 << idx_partFlag));
					}
					idx_renderer++;
				}
				idx_partFlag++;
				unlockFlag >>= 1;
				lockFlag >>= 1;
			}

			for (; idx_renderer < listOfIconRenderers.Count;idx_renderer++) {
				// Renderer is left after assigning all unlocks, so disenable renderers
				AssignIconRenderer(listOfIconRenderers[idx_renderer], WeaponMod.Status.Unused, null, 0x0);
			}
		}

		private ModIconRenderer CreateNewIcon(float shift) {
			Vector3 IconOffset = m_IconParent.position;
			IconOffset.x += shift * 50f;

			ModIconRenderer newRenderer = Instantiate(m_IconObject,IconOffset, Quaternion.identity, m_IconParent).GetComponent<ModIconRenderer>();
			listOfIconRenderers.Add(newRenderer);
			return newRenderer;
		}

		private void AssignIconRenderer(ModIconRenderer iconRenderer, WeaponMod.Status status, ModInstance weaponMod, WeaponMod.ModPart part) {

		}
	}
}