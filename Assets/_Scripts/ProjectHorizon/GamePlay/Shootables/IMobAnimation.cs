using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.meiguofandian.ProjectHorizon.GamePlay.Shootables {
	public interface IMobAnimation {
		void Attacked();
		void StartMelee();
		void StopMelee();
		void Death();
	}
}