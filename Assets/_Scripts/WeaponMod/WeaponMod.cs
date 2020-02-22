using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.weaponMod {
	public class WeaponMod {
		[Flags]
		public enum ModPart : UInt64{
			None = 0,
			Receiver = 1,
			Handle = 2,
			Stock = 4,
			Magazine = 8,
			Barrel = 16,
			Handguard = 32,
			Underbarrel = 64,
			Sidebarrel = 128,
			Nozzle = 256,
			Scope = 512
		}

		public enum ReqInfo {
			Mainly = 0,
			Requires = 1,
			Locks = 2,
			Unlocks = 3
		}

		public string m_Name;
		public Sprite m_Visuals;
		public List<VisualDisplacement> m_DisplacementList;
		public UInt64[] m_requirementInformation = new UInt64[Enum.GetNames(typeof(ReqInfo)).Length];

		public static string DEBUG_PRINT_FLAG(UInt64 flag) {
			return String.Format("{0,3} - {1:G}", flag, (ModPart)flag);
		}
	}
}
