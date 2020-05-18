using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.LPlatformer {
	[CreateAssetMenu(fileName = "New Map", menuName = "ProjectHorizon/LPlatformer/Map")]
	public class MapData:ScriptableObject {
		public MapComponent[] Components;

		public const int COMPONENT_TYPE_SIZE = 4; 
		public enum ComponentType {
			FLOOR,		// BLOCKS FALLING
			CEILING,	// BLOCKS JUMPING OVER IT
			WALL,		// BLOCKS SIDEWAY MOVEMENTS
			BEDROCK		// BLOCKS DOWNWARD JUMPING
		}

		[Serializable]
		public class MapComponent {
			public ComponentType CType;
			public Vector2[] Points;
		}
	}
}