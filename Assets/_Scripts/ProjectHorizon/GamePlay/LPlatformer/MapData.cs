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
		public TriggerComponent[] Triggers;
		public DropElement[] DropTable;

		public const int COMPONENT_TYPE_SIZE = 5; 
		public enum ComponentType {
			FLOOR,		// BLOCKS FALLING
			CEILING,	// BLOCKS JUMPING OVER IT
			WALL,		// BLOCKS SIDEWAY MOVEMENTS
			BEDROCK,	// BLOCKS DOWNWARD JUMPING
			LAVA		// WILL KILL THE PLAYER INSTANTLY
		}

		public const int TRIGGER_TYPE_SIZE = 2;
		public enum TriggerType {
			PLAYER_START,
			HOSTILE_MOB
		}

		[Serializable]
		public class MapComponent {
			public ComponentType CType;
			public Vector2[] Points;
		}

		[Serializable]
		public class TriggerComponent {
			public TriggerType TType;
			public Vector2 Position;
			public GameObject Instantiatable;

			public void InitiateTrigger() {
				switch (TType) {
				case TriggerType.PLAYER_START:
					GameObject.Find("PlayerCharacter").transform.localPosition = Position;
					break;
				case TriggerType.HOSTILE_MOB:
					Instantiate(Instantiatable, Position, Quaternion.identity);
					break;
				}
			}
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