using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.Modules.SpriteShaders {
	public class ChildRecolor : MonoBehaviour {
		public Material shader;

		public void ApplyShader() {
			SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
			foreach(SpriteRenderer spr in spriteRenderers) {
				spr.sharedMaterial = shader;
			}
		}
	}
}