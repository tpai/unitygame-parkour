using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	Animator walkAnim;
	Animator monAnim;
	public int hp = 1;

	void Start () {
		walkAnim = transform.Find ("Main").GetComponent<Animator> ();
		monAnim = transform.Find ("Main").Find ("Animation").GetComponent<Animator> ();
	}
	
	void KillByPlayer () {
		hp --;
		if(hp == 0) {
			rigidbody.useGravity = false;
			rigidbody.isKinematic = true;
			monAnim.SetTrigger ("dead");
			walkAnim.enabled = false;
		}
	}
}
