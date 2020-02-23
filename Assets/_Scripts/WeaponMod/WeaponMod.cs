﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.meiguofandian.weaponMod {
	[CreateAssetMenu(fileName = "New Mod", menuName = "ProjectHorizon/Weapon/WeaponMod")]
	public class WeaponMod : ScriptableObject {
		[Flags]
		public enum ModPart : UInt32{
			Receiver	= 0x001,
			Handle		= 0x002,
			Stock		= 0x004,
			Magazine	= 0x008,
			Barrel		= 0x010,
			Handguard	= 0x020,
			Underbarrel = 0x040,
			Sidebarrel	= 0x080,
			Nozzle		= 0x100,
			Scope		= 0x200
		}

		public string m_ModName;
		public Sprite m_Visuals;
		public List<VisualDisplacement> m_DisplacementList;
		public ModPart m_Mainly;
		[enumFlagsAsToggleButtons.EnumFlag]
		public ModPart m_Requires;
		[enumFlagsAsToggleButtons.EnumFlag]
		public ModPart m_Locks;
		[enumFlagsAsToggleButtons.EnumFlag]
		public ModPart m_Unlocks;
		public Statistics m_Stats;

		public static string DEBUG_PRINT_FLAG(UInt64 flag) {
			return String.Format("{0,3} - {1:G}", flag, (ModPart)flag);
		}
	}
}
