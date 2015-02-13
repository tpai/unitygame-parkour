using UnityEngine;
using System.Collections;

public class PlayerSFX : MonoBehaviour {

	public AudioClip[] clips;
	Player player;

	void Start () {
		player = GameObject.Find ("Player").GetComponent<Player> ();
	}

	public void JumpSound () {
		if(!player.isDead) {
			audio.clip = clips[0];
			audio.Play();
		}
	}

	public void ShootSound () {
		if(!player.isDead) {
			audio.clip = clips[1];
			audio.Play();
		}
	}

	public void DieSound () {
		audio.clip = clips[2];
		audio.Play ();
	}
}
