using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCtrlButton : MonoBehaviour {

	bool hiddenTip = false;

	void HideTip () {
		if(!hiddenTip) {
			hiddenTip = true;
			GameObject.Find ("Jump").GetComponent<Image>().color = Color.clear;
			GameObject.Find ("Jump").transform.Find("Text").GetComponent<Text>().color = Color.clear;
			GameObject.Find ("Shoot").GetComponent<Image>().color = Color.clear;
			GameObject.Find ("Shoot").transform.Find("Text").GetComponent<Text>().color = Color.clear;
		}
	}

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

		HideTip ();
	}
}
