using UnityEngine;
using System.Collections;

public class Bat : MonoBehaviour {

	Animator anim;
	public float restSeconds = 3f;
	bool countDown = false;
	bool dropped = false;

	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update () {
		if(dropped == false && countDown == true) {

			if(restSeconds >= 0)
				restSeconds -= Time.deltaTime;
			else
				anim.SetTrigger("drop");
		}
	}

	void OnCollisionEnter (Collision coll) {
		if(coll.collider.tag == "Player") {
			countDown = true;
		}
	}

	void OnCollisionExit (Collision coll) {
		if(coll.collider.tag == "Player") {
			countDown = false;
		}
	}
}
