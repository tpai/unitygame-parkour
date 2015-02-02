using UnityEngine;
using System.Collections;

public class BlockPlatform : MonoBehaviour {

	Animator anim;

	void Start () {
		anim = GetComponentInChildren<Animator> ();
	}

	void OnTriggerEnter (Collider other) {
		if(other.tag == "Player") {
			anim.SetBool("go", true);
		}
	}
}
