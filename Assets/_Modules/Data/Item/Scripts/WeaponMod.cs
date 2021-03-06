﻿using System;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.Modules.EnumFlagsAsToggleButtons;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	[CreateAssetMenu(fileName = "New Mod", menuName = "ProjectHorizon/Weapon/WeaponMod")]
	public class WeaponMod : ItemReference {
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
			Scope		= 0x200,
			Flare		= 0x400,	// This isn't a part but used for visual displacement
			Mount		= 0x800		// For Russian Side Mount
		}

		public enum Status : byte {
			Unused,
			Unlocked,
			Locked,
			Requires
		}

		/// <summary>
		/// This Method will return the modpart in normal int way
		/// It will return receiver as 1 so if you use this for Array index purpose
		/// add one to it
		/// </summary>
		/// <param name="part">The ModPart</param>
		/// <returns>Index of Modpart</returns>
		public static int GetModPartIDX(ModPart part) {
			UInt32 flagData = (UInt32)part;
			int idx = 1;
			while(flagData > 0) {
				if (( flagData & 0x1 ) == 0x1) {
					return idx;
				}
				idx++;
				flagData >>= 1;
			}
			return -1;
		}

		public string m_ModName;
		public Sprite m_Visuals;
		public List<VisualDisplacement> m_DisplacementList;
		public ModPart m_Mainly;
		[EnumFlag]
		public ModPart m_Requires;
		[EnumFlag]
		public ModPart m_Locks;
		[EnumFlag]
		public ModPart m_Unlocks;
		public Statistics m_Stats;

		public override string GetName() {
			return "Item_Mod_" + m_ModName;
		}

		public override Sprite GetSprite() {
			return m_Visuals;
		}

		public static string DEBUG_PRINT_FLAG(UInt64 flag) {
			return String.Format("{0,3} - {1:G}", flag, (ModPart)flag);
		}
	}
}
