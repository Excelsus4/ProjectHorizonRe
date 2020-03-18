using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	public class StatDisplay : MonoBehaviour {
		public Slider MainSlider;
		public Slider SubSlider;
		public Text NumericText;

		public void SetStatus(float Max, float Main, float Sub, string Value) {
			MainSlider.maxValue = Max;
			SubSlider.maxValue = Max;
			MainSlider.value = Main;
			SubSlider.value = Sub;
			NumericText.text = Value;
		}
	}
}