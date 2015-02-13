using UnityEngine;
using System.Collections;

public class PlayerCtrlButton : MonoBehaviour {

	public void ButtonClick (string buttonType) {

		Player player = GameObject.Find ("Player").GetComponent<Player> ();
		PlayerShoot playershoo = GameObject.Find ("Player").GetComponent<PlayerShoot> ();

		bool isDead = player.isDead;
		bool isJumping = player.isJumping;

		if(buttonType == "Shoot") {
			// shoot
			if(isDead == false) {
				playershoo.ApplyFire();
			}
		}
		else if(buttonType == "Jump") {
			// jump
			if(
				isDead == false && 
				isJumping == false
			) {
				player.ApplyJump();
			}
		}
	}
}
