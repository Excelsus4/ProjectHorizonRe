using System;
using UnityEngine;

namespace com.meiguofandian.weaponMod {
	[Serializable]
	public class VisualDisplacement {
		[enumFlagsAsToggleButtons.EnumFlag]
		public WeaponMod.ModPart targetPart;
		public Vector2 displacement;
	}
}
