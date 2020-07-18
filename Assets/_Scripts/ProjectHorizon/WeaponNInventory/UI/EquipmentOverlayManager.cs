using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.Modules.ObserverPattern;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	public class EquipmentOverlayManager : MonoBehaviour,IModIconButtonCallback, IDataUpdateCallback {
		private List<ModIconRenderer> listOfIconRenderers = new List<ModIconRenderer>();



		public GameObject m_IconObject;
		public Transform m_IconParent;
		public float m_IconSize;
		public float m_IconGap;


		public void ModIconCallback(int IDX, InventoryItem part) {
			throw new System.NotImplementedException();
		}

		public void OnDataUpdate(string data) {
			throw new System.NotImplementedException();
		}
	}
}