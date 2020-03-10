using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.projectHorizon.inventory {
	public abstract class ItemReference : ScriptableObject {
		public abstract string GetName();
	}
}
