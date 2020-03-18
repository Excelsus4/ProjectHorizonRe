using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace com.meiguofandian.ProjectHorizon.GamePlay.Shooting {
	public class VoxelBackgroundCanvas : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
		public VoxelInputControl movementScript;

		public void OnPointerDown(PointerEventData eventData) {
			movementScript.OnMDown();
		}

		public void OnPointerUp(PointerEventData eventData) {
			movementScript.OnMUp();
		}
	}
}