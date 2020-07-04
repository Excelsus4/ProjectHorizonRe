using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.ProjectHorizon.WeaponNInventory;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer {
	[CreateAssetMenu(fileName = "New Map", menuName = "ProjectHorizon/LPlatformer/Map")]
	public class MapData:ScriptableObject {
		public string Title;
		public string Description;
		public MapComponent[] Components;
		public MapSystem.Trigger[] Triggers;
		public DropElement[] DropTable;

		public const int COMPONENT_TYPE_SIZE = 5; 
		public enum MapType {
			FLOOR,		// BLOCKS FALLING
			CEILING,	// BLOCKS JUMPING OVER IT
			WALL,		// BLOCKS SIDEWAY MOVEMENTS
			BEDROCK,	// BLOCKS DOWNWARD JUMPING
			LAVA		// WILL KILL THE PLAYER INSTANTLY
		}

		[Serializable]
		public class MapComponent {
			public MapType Type;
			public Vector2[] Points;
		}

		[Serializable]
		public class DropElement {
			public InventoryItem ItemInstance;
			public float DropChance;
			public int MinAmount;
			public int MaxAmount;
		}
	}
}