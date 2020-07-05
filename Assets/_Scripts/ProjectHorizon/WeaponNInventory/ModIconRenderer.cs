using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	public class ModIconRenderer : MonoBehaviour {
		public InventoryItem target;
		public RectTransform iconTransform;
		public UnityEngine.UI.Image iconImage;
		public UnityEngine.UI.Image frameImage;
		public UnityEngine.UI.Image buttonImage;
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
			case MaterialInstance resource:
				iconTransform.localScale = resource.m_Reference.m_Visuals.bounds.extents;
				iconImage.sprite = resource.m_Reference.m_Visuals;
				break;
			}
		}

		public void ButtonDownCallback() {
			if (target != null)
				callbackManager.ModIconCallback(callbackIndex, target);
		}

		public void IconAble(bool isEnable) {
			Color tempColor = isEnable ? Color.white : Color.clear;
			buttonImage.color = tempColor;
			iconImage.color = tempColor;
			frameImage.color = tempColor;
		}
	}
}