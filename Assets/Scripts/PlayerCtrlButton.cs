using UnityEngine;
using System.Collections;

public class PlayerCtrlButton : MonoBehaviour {

	public void ButtonClick (string buttonType) {

		PlayerMovement playermov = GameObject.Find ("Player").GetComponent<PlayerMovement> ();

		bool isDead = playermov.isDead;
		bool isJumping = playermov.isJumping;

		if(buttonType == "Shoot") {
			// shoot

		}
		else if(buttonType == "Jump") {
			// jump
			if(
				isDead == false && 
				isJumping == false
			) {
				playermov.ApplyJump();
			}
		}
	}
}
