using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code modified from unity MicrogamePlatformer Tutorial
namespace com.meiguofandian.ProjectHorizon.GamePlay.Platformer {
	/// <summary>
	/// Fired when the player character lands after being airborne.
	/// </summary>
	/// <typeparam name="PlayerLanded"></typeparam>
	public class PlayerLanded : Simulation.Event<PlayerLanded> {
		public PlayerController player;

		public override void Execute() {

		}
	}
}