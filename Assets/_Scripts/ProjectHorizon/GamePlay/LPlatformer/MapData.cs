﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer {
	[CreateAssetMenu(fileName = "New Map", menuName = "ProjectHorizon/LPlatformer/Map")]
	public class MapData:ScriptableObject {
		public MapComponent[] Components;
		public TriggerComponent[] Triggers;

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
		}
	}
}