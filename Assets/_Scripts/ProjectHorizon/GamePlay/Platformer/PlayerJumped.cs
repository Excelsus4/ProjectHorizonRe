using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code modified from unity MicrogamePlatformer Tutorial
namespace com.meiguofandian.ProjectHorizon.GamePlay.Platformer {
	/// <summary>
	/// Fired when the player performs a Jump.
	/// </summary>
	/// <typeparam name="PlayerJumped"></typeparam>
	public class PlayerJumped : Simulation.Event<PlayerJumped> {
		public PlayerController player;

		public override void Execute() {
			if (player.audioSource && player.jumpAudio)
				player.audioSource.PlayOneShot(player.jumpAudio);
		}
	}
}