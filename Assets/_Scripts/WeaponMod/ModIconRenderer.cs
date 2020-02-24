using UnityEngine;
using com.meiguofandian.weaponMod;

namespace com.meiguofandian.weaponRenderer {
	public class ModIconRenderer : MonoBehaviour {
		public ModInstance target;
		public RectTransform iconTransform;
		public UnityEngine.UI.Image iconImage;

		private void Start() {
			UpdateImage();
		}

		public void UpdateImage() {
			if (target != null) {
				iconTransform.localScale = target.m_Reference.m_Visuals.bounds.extents;
				iconImage.sprite = target.m_Reference.m_Visuals;
			} else
				iconImage.sprite = null;
		}
	}
}