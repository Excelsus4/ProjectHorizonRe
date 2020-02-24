using System;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.weaponMod;

namespace com.meiguofandian.weaponRenderer {
	public class WeaponRenderer : MonoBehaviour {
		private List<ModSpriteRenderer> listOfSpriteRenderers = new List<ModSpriteRenderer>();
		private Vector2[] shiftMatrix = new Vector2[Enum.GetNames(typeof(WeaponMod.ModPart)).Length];
		public weaponMod.Weapon m_WeaponToRender;
		public GameObject m_RendererPrefab;

		private void Start() {
			Render();
		}

		public void Render() {
			// Calculate Shift Offsets for each part
			for (int mod_idx = 0; mod_idx < m_WeaponToRender.weaponModList.Count; mod_idx++) {
				for (int dsp_idx = 0; dsp_idx < m_WeaponToRender.weaponModList[mod_idx].m_Reference.m_DisplacementList.Count; dsp_idx++) {
					CalculateShift(m_WeaponToRender.weaponModList[mod_idx].m_Reference.m_DisplacementList[dsp_idx]);
				}
			}

			// Adjust Renderers
			int maxCount =
				m_WeaponToRender.weaponModList.Count > listOfSpriteRenderers.Count
				? m_WeaponToRender.weaponModList.Count
				: listOfSpriteRenderers.Count;
			for (int idx = 0; idx < maxCount; idx++) {
				if (idx < listOfSpriteRenderers.Count && idx < m_WeaponToRender.weaponModList.Count) {
					// Assign one renderer for each mod instance.
					AssignRenderer(listOfSpriteRenderers[idx], m_WeaponToRender.weaponModList[idx]);
				} else if (idx < listOfSpriteRenderers.Count) {
					// Renderers are left, nullize left over renderers.
					AssignRenderer(listOfSpriteRenderers[idx], null);
				} else if (idx < m_WeaponToRender.weaponModList.Count) {
					// Not enough renderer for modlist, create more renderers.
					CreateNewRenderer();
					AssignRenderer(listOfSpriteRenderers[idx], m_WeaponToRender.weaponModList[idx]);
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
	}
}