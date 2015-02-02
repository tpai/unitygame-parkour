using UnityEngine;
using System.Collections;

public class BlockPlatform_DollArm : MonoBehaviour {

	Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	void OnCollisionEnter (Collision coll) {
		if(coll.collider.tag == "Player") {
			anim.SetBool("go", false);
		}
	}
}
