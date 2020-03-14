using System;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.weaponMod;
using com.meiguofandian.core;
using com.meiguofandian.projectHorizon.inventory;

namespace com.meiguofandian.weaponRenderer {
	public class WeaponRenderer : MonoBehaviour, IDataUpdateCallback {
		private List<ModSpriteRenderer> listOfSpriteRenderers = new List<ModSpriteRenderer>();
		private Vector2[] shiftMatrix;
		private UserHandWeaponData GlobalWeaponManager;
		public weaponMod.Weapon WeaponToRender;
		public GameObject m_RendererPrefab;

		private void Start() {
			GlobalWeaponManager = UserHandWeaponData.getSingleton();
			GlobalWeaponManager.RegisterObserver(this);
		}

		public void Render() {
			if (WeaponToRender == null) {
				for(int idx = 0; idx < listOfSpriteRenderers.Count; idx++) {
					AssignRenderer(listOfSpriteRenderers[idx], null);
				}
				return;
			}

			// Calculate Shift Offsets for each part
			shiftMatrix = new Vector2[Enum.GetNames(typeof(WeaponMod.ModPart)).Length];
			for (int mod_idx = 0; mod_idx < WeaponToRender.weaponModList.Count; mod_idx++) {
				for (int dsp_idx = 0; dsp_idx < WeaponToRender.weaponModList[mod_idx].m_Reference.m_DisplacementList.Count; dsp_idx++) {
					CalculateShift(WeaponToRender.weaponModList[mod_idx].m_Reference.m_DisplacementList[dsp_idx]);
				}
			}

			// Adjust Renderers
			int maxCount =
				WeaponToRender.weaponModList.Count > listOfSpriteRenderers.Count
				? WeaponToRender.weaponModList.Count
				: listOfSpriteRenderers.Count;
			for (int idx = 0; idx < maxCount; idx++) {
				if (idx < listOfSpriteRenderers.Count && idx < WeaponToRender.weaponModList.Count) {
					// Assign one renderer for each mod instance.
					AssignRenderer(listOfSpriteRenderers[idx], WeaponToRender.weaponModList[idx]);
				} else if (idx < listOfSpriteRenderers.Count) {
					// Renderers are left, nullize left over renderers.
					AssignRenderer(listOfSpriteRenderers[idx], null);
				} else if (idx < WeaponToRender.weaponModList.Count) {
					// Not enough renderer for modlist, create more renderers.
					CreateNewRenderer();
					AssignRenderer(listOfSpriteRenderers[idx], WeaponToRender.weaponModList[idx]);
				}
			}
		}

		private void CalculateShift(VisualDisplacement shiftData) {
			UInt32 flagData = (UInt32)shiftData.targetPart;
			int idx = 0;
			while (flagData > 0) {
				if (( flagData & 0x1 ) == 0x1) {
					shiftMatrix[idx] += shiftData.displacement;
				}
				idx++;
				flagData >>= 1;
			}
		}

		private void CreateNewRenderer() {
			listOfSpriteRenderers.Add(Instantiate(m_RendererPrefab, transform).GetComponent<ModSpriteRenderer>());
		}

		private void AssignRenderer(ModSpriteRenderer renderer, ModInstance target) {
			renderer.target = target;
			if(target != null) {
				renderer.SetTransform(shiftMatrix[WeaponMod.GetModPartIDX(target.m_Reference.m_Mainly)-1]);
			}
			renderer.UpdateImage();
		}

		public void OnDataUpdate() {
			WeaponToRender = GlobalWeaponManager.weapon;
			Render();
		}
	}
}