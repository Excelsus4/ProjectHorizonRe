using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code modified from unity MicrogamePlatformer Tutorial
namespace com.meiguofandian.platformer {
	/// <summary>
	/// Fired when the Jump Input is deactivated by the user, cancelling the upward velocity of the jump.
	/// </summary>
	/// <typeparam name="PlayerStopJump"></typeparam>
	public class PlayerStopJump : Simulation.Event<PlayerStopJump> {
		public PlayerController player;

		public override void Execute() {

		}
	}
}