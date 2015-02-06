using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Animator anim;
	public bool isDead = false;
	public bool isJumping = false;
	public bool onPlatform = false;
	public float speed = 3f;
	public float jumpForce = 800f;

	void Start () {
		anim = GetComponentInChildren<Animator>();
		anim.SetBool("IsWalking", true);
	}

	void Update () {

		if(isDead == true){}
		else if(isJumping == false && Input.GetButtonDown("Jump")) {
			isJumping = true;
			anim.SetBool("IsWalking", false);

			/*float forwardForce;
			if(onPlatform == true)forwardForce = 400;
			else forwardForce = 0;*/

			rigidbody.AddForce(new Vector3((onPlatform)?250:0, jumpForce, 0));
		}
		else if(onPlatform == true){}
		else {
			rigidbody.velocity = new Vector3(speed, rigidbody.velocity.y, 0);
		}
	}

	void OnCollisionEnter (Collision coll) {
		if(coll.collider.tag == "Ground") {
			isJumping = false;
			onPlatform = false;
			anim.SetBool("IsWalking", true);
		}
	}

	void OnCollisionStay(Collision coll) {
		if(coll.collider.tag == "Platform") {
			isJumping = false;
			onPlatform = true;
			transform.parent = coll.transform;
		}
		else {
			transform.parent = null;
		}
	}

	void Die () {
		isDead = true;
		anim.SetTrigger("Die");
	}
}
