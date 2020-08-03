using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace com.meiguofandian.ProjectHorizon.Clothing {
	public class HumanoidDresser : MonoBehaviour {
		public enum EquipmentVisualPart {
			Head,
			Thorax_Inner, Thorax_Outer,
			Stomach,
			Shoulder_Left, Shoulder_Right,
			UpperArm_Left, UpperArm_Right,
			LowerArm_Left, LowerArm_Right,
			UpperLeg_Left, UpperLeg_Right,
			LowerLeg_Left, LowerLeg_Right,
			Foot_Left, Foot_Right
		}

		[Serializable]
		public struct EquipmentVisual {
			public EquipmentVisualPart Part;
			public Sprite Visual;
			public int Priority;
		}

		public Transform[] TransformInPartOrder; 
		public List<EquipmentVisual> m_Visuals;
		public GameObject SpritePrefab;

		private List<SpriteRenderer> InstantiatedSprites = new List<SpriteRenderer>();

		public void ClearVisuals() {
			foreach(SpriteRenderer sr in InstantiatedSprites) {
				Destroy(sr.gameObject);
			}
			InstantiatedSprites.Clear();
			m_Visuals.Clear();
		}

		public void Dress() {
			// TODO: Add the dressing algorithm HERE
			foreach(EquipmentVisual vis in m_Visuals) {
				SpriteRenderer renderer = Instantiate(SpritePrefab, TransformInPartOrder[(int)vis.Part]).GetComponent<SpriteRenderer>();
				InstantiatedSprites.Add(renderer);
				renderer.sprite = vis.Visual;
				renderer.sortingOrder = vis.Priority;
			}
		}
	}
}