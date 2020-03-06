﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.weaponMod;
using com.meiguofandian.weaponRenderer;

namespace com.meiguofandian.projectHorizon.manager {
	public class WeaponOverlayManager : MonoBehaviour {
		public enum OverlayIconType {
			WeaponMod,
			InventoryMod
		}

		private List<ModIconRenderer> listOfIconRenderers = new List<ModIconRenderer>();
		public weaponMod.Weapon m_WeaponToRender;
		public weaponRenderer.WeaponRenderer m_PrimaryRenderer;
		public GameObject m_IconObject;
		public Transform m_IconParent;
		public float m_IconSize;
		public float m_IconGap;

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
						AssignIconRenderer(listOfIconRenderers[idx_renderer], 
							flag_status, 
							m_WeaponToRender.GetModInstance((WeaponMod.ModPart)(0x1 << idx_partFlag)), 
							(WeaponMod.ModPart)( 0x1 << idx_partFlag ));
					} else {
						// Not enough Iconrenderer, create more and assign new
						AssignIconRenderer(CreateNewIcon(idx_renderer), 
							flag_status,
							m_WeaponToRender.GetModInstance((WeaponMod.ModPart)( 0x1 << idx_partFlag )), 
							(WeaponMod.ModPart)(0x1 << idx_partFlag));
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

		private ModIconRenderer CreateNewIcon(int index) {
			Vector3 IconOffset = m_IconParent.position;
			IconOffset.x += index * m_IconGap + m_IconSize;

			ModIconRenderer newRenderer = Instantiate(m_IconObject,IconOffset, Quaternion.identity, m_IconParent).GetComponent<ModIconRenderer>();
			newRenderer.iconType = OverlayIconType.WeaponMod;
			newRenderer.callbackIndex = index;
			listOfIconRenderers.Add(newRenderer);
			return newRenderer;
		}

		private void AssignIconRenderer(ModIconRenderer iconRenderer, WeaponMod.Status status, ModInstance weaponMod, WeaponMod.ModPart part) {
			iconRenderer.callbackManager = this;
			iconRenderer.target = weaponMod;
			iconRenderer.UpdateImage();
		}

		public void ModIconCallback(OverlayIconType iconType, int IDX, WeaponMod.ModPart part) {
			print("callback by " + iconType + " number " + IDX + " at " + part);
			m_WeaponToRender.RemoveMod(part);
			Render();
			m_PrimaryRenderer.Render();
		}
	}
}