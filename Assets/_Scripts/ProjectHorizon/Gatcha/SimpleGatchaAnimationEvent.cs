using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.ProjectHorizon.WeaponNInventory;

namespace com.meiguofandian.ProjectHorizon.Gatcha {
	public class SimpleGatchaAnimationEvent : MonoBehaviour {
		private InventoryItem output;
		public SpriteRenderer OnTong;

		public void SetAnimation(InventoryItem input, InventoryItem output) {
			OnTong.sprite = input.GetReference().GetSprite();
			this.output = output;
		}

		public void Cool() {
			OnTong.sprite = output.GetReference().GetSprite();
		}
	}
}