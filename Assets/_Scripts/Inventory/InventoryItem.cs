using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.projectHorizon.inventory { 
	public abstract class InventoryItem : ScriptableObject {
		public abstract string GetReferenceName();

		public static InventoryItem CreateByReferenceName(string referenceName) {
			return null;
		}
	}
}