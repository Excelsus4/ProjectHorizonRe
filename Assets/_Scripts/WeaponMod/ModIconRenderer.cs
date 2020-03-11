using UnityEngine;
using com.meiguofandian.weaponMod;
using com.meiguofandian.projectHorizon.manager;
using com.meiguofandian.projectHorizon.inventory;

namespace com.meiguofandian.weaponRenderer {
	public class ModIconRenderer : MonoBehaviour {
		public InventoryItem target;
		public RectTransform iconTransform;
		public UnityEngine.UI.Image iconImage;
		public IModIconButtonCallback callbackManager;
		public int callbackIndex;

		private void Start() {
			UpdateImage();
		}

		public void UpdateImage() {
			switch (target) {
			case null:
				iconImage.sprite = null;
				break;
			case ModInstance mod:
				iconTransform.localScale = mod.m_Reference.m_Visuals.bounds.extents;
				iconImage.sprite = mod.m_Reference.m_Visuals;
				break;
			}
		}

		public void ButtonDownCallback() {
			if (target != null)
				callbackManager.ModIconCallback(callbackIndex, target);
		}
	}
}