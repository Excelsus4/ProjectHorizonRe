using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.Modules.NumberedDamage {
	[CreateAssetMenu(fileName ="New DamageSkin", menuName ="Module/DamageSkin")]
	public class DamageSkin : ScriptableObject {
		public Sprite[] fromZeroToNine = new Sprite[10];
	}
}