using System;
using UnityEngine;
using com.meiguofandian.Modules.EnumFlagsAsToggleButtons;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	[Serializable]
	public class VisualDisplacement {
		[EnumFlag]
		public WeaponMod.ModPart targetPart;
		public Vector2 displacement;
	}
}
