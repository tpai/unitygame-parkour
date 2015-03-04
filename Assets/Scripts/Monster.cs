using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	ParticleSystem hitParticle;
	Animator walkAnim;
	Animator monAnim;
	public int hp = 1;

	public int monId;
	public AudioClip[] monSFX;

	void Start () {
		walkAnim = transform.Find ("Main").GetComponent<Animator> ();
		monAnim = transform.Find ("Main").Find ("Animation").GetComponent<Animator> ();
		hitParticle = GetComponentInChildren<ParticleSystem>();
	}
	
	void KillByPlayer (Vector3 hitPoint) {
		hp --;
		hitParticle.transform.position = hitPoint;
		hitParticle.Play();
		if(hp == 0) {
			GetComponent<Rigidbody>().useGravity = false;
			GetComponent<Rigidbody>().isKinematic = true;
			monAnim.SetTrigger ("dead");
			walkAnim.enabled = false;

			GetComponent<AudioSource>().clip = monSFX[monId+1];
			GetComponent<AudioSource>().Play();
		}
		else {
			GetComponent<AudioSource>().clip = monSFX[monId];
			GetComponent<AudioSource>().Play();
		}
	}
}
