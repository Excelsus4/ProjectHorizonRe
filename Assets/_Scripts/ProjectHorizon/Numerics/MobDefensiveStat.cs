using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.Numerics {
	[CreateAssetMenu(fileName = "New Mob Stat", menuName = "ProjectHorizon/Numerics/MobDefenceStat")]
	public class MobDefensiveStat : ScriptableObject {
		public int Health;
		public int Armor;
		public string[] Tags;
	}
}