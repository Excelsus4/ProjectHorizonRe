using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	public class ModSpriteRenderer : MonoBehaviour {
		public ModInstance target;
		public Transform spriteTransform;
		public SpriteRenderer spriteImage;

		private void Start() {
			UpdateImage();
		}

		public void UpdateImage() {
			if(target != null) {
				spriteImage.sprite = target.m_Reference.m_Visuals;
			} else {
				spriteImage.sprite = null;
			}
		}

		public void SetTransform(Vector2 offset) {
			spriteTransform.localPosition = offset;
		}
	}
}