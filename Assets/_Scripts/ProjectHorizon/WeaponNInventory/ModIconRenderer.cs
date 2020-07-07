using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	public class ModIconRenderer : MonoBehaviour {
		public InventoryItem target;
		public RectTransform iconTransform;
		public UnityEngine.UI.Image iconImage;
		public UnityEngine.UI.Image frameImage;
		public UnityEngine.UI.Image buttonImage;
		public UnityEngine.UI.Text dataText;
		public IModIconButtonCallback callbackManager;
		public int callbackIndex;

		private void Start() {
		}

		public void UpdateImage() {
			switch (target) {
			case null:
				iconImage.sprite = null;
				iconImage.color = Color.clear;
				//frameImage.sprite = null;
				dataText.text = "";
				break;
			case ModInstance mod:
				iconTransform.localScale = mod.m_Reference.m_Visuals.bounds.extents;
				iconImage.sprite = mod.m_Reference.m_Visuals;
				iconImage.color = Color.white;
				dataText.text = "+"+mod.m_Upgrades[0].ToString();
				break;
			case MaterialInstance resource:
				iconTransform.localScale = resource.m_Reference.m_Visuals.bounds.extents;
				iconImage.sprite = resource.m_Reference.m_Visuals;
				iconImage.color = Color.white;
				dataText.text = resource.m_Amount.ToString();
				break;
			}
		}
		
		public void SetDropTableText(GamePlay.LPlatformer.MapData.DropElement drop) {
			string temp = ( drop.DropChance * 100 ) + "%\n";
			switch (drop.ItemInstance) {
			case ModInstance mod:
				temp += "+"+mod.m_Upgrades[0];
				break;
			case MaterialInstance res:
				temp += res.m_Amount * drop.MinAmount + "~" + res.m_Amount * drop.MaxAmount;
				break;
			}
			dataText.text = temp;
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
			dataText.text = "";
		}
	}
}