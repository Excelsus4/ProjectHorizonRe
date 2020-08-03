using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.ProjectHorizon.GamePlay.Shooting {
	public class VoxelHandCallback : MonoBehaviour {
		public enum CallBackAnimationState {
			Fire,
			Reload,
			Swap
		}

		public VoxelInputControl m_VoxelInputControl;
		public VoxelAnimationControl m_VoxelAnimationControl;
		public CallBackAnimationState m_State;

		private void OnEnable() {
			print("Arghh");
			switch (m_State) {
			case CallBackAnimationState.Fire:
				m_VoxelAnimationControl.m_HighAnimator.SetInteger("Fire", m_VoxelAnimationControl.m_HighAnimator.GetInteger("Fire") - 1);
				if (m_VoxelAnimationControl.m_HighAnimator.GetInteger("Fire") == 0) {
					m_VoxelInputControl.m_LockAction = false;
					m_VoxelAnimationControl.m_HighAnimator.speed = 1f;
				}
				break;
			case CallBackAnimationState.Reload:
				m_VoxelInputControl.m_LockAction = false;
				m_VoxelInputControl.ReloadComplete();
				m_VoxelAnimationControl.m_HighAnimator.speed = 1f;
				break;
			}
			this.enabled = false;
		}
	}
}