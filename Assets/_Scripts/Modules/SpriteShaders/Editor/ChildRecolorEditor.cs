using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace com.meiguofandian.Modules.SpriteShaders {
	[CustomEditor(typeof(ChildRecolor))]
	public class ChildRecolorEditor : Editor {
		public override void OnInspectorGUI() {
			base.OnInspectorGUI();

			ChildRecolor recolor = (ChildRecolor)target;
			if (GUILayout.Button("Apply Shader")) {
				recolor.ApplyShader();
			}
		}
	}
}