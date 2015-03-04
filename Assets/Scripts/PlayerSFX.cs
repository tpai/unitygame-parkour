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
			GetComponent<AudioSource>().clip = clips[0];
			GetComponent<AudioSource>().Play();
		}
	}

	public void ShootSound () {
		if(!player.isDead) {
			GetComponent<AudioSource>().clip = clips[1];
			GetComponent<AudioSource>().Play();
		}
	}

	public void DieSound () {
		GetComponent<AudioSource>().clip = clips[2];
		GetComponent<AudioSource>().Play ();
	}
}
