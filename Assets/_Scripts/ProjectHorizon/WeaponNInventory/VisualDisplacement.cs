using System;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	[Serializable]
	public class VisualDisplacement {
		[enumFlagsAsToggleButtons.EnumFlag]
		public WeaponMod.ModPart targetPart;
		public Vector2 displacement;
	}
}
