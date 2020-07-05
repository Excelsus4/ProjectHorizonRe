using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	public class LootBarManager : MonoBehaviour, IModIconButtonCallback {
		private List<ModIconRenderer> listOfIconRenderers = new List<ModIconRenderer>();

		public GameObject m_IconObject;
		public Transform m_IconParent;
		public float[] m_IconSize = new float[2];
		public float[] m_IconGap = new float[2];
		public int m_IconColumn;

		public void UpdateDropTable(MapData.DropElement[] DropTable) {
			int idx;

			for (idx = 0; idx < DropTable.Length; idx++) {
				if (listOfIconRenderers.Count <= idx) {
					// Not Enough Icons
					AssignIconRenderer(CreateNewIcon(idx), DropTable[idx].ItemInstance);
				} else {
					// Prepared Icons
					AssignIconRenderer(listOfIconRenderers[idx], DropTable[idx].ItemInstance);
				}
			}

			// Left over icons
			for (; idx < listOfIconRenderers.Count; idx++) {
				listOfIconRenderers[idx].IconAble(false);
			}
		}


		private ModIconRenderer CreateNewIcon(int index) {
			Vector3 IconOffset = m_IconParent.position;
			IconOffset.x += ( index % m_IconColumn ) * m_IconGap[0] + m_IconSize[0];
			IconOffset.y += ( index / m_IconColumn ) * m_IconGap[1] + m_IconSize[1];

			ModIconRenderer newRenderer = Instantiate(m_IconObject, IconOffset, Quaternion.identity, m_IconParent).GetComponent<ModIconRenderer>();
			newRenderer.callbackIndex = index;
			listOfIconRenderers.Add(newRenderer);
			return newRenderer;
		}

		private void AssignIconRenderer(ModIconRenderer iconRenderer, InventoryItem weaponMod) {
			iconRenderer.IconAble(true);
			iconRenderer.callbackManager = this;
			iconRenderer.target = weaponMod;
			iconRenderer.UpdateImage();
		}

		public void ModIconCallback(int IDX, InventoryItem part) {
			if (part is ModInstance mod) {
				// Do whatever the mod is suppose to do. probably an inspect window
			} else {
				// Do whatever the item is suppose to do. probably an inspect window
			}
		}
	}
}