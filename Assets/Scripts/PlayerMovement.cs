using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Animator anim;
	bool isJumping = false;
	public float speed = 3f;
	public float jumpForce = 800f;

	void Start () {
		anim = GetComponentInChildren<Animator>();
		anim.SetBool("IsWalking", true);
	}

	void Update () {

		if(isJumping == false && Input.GetButtonDown("Jump")) {
			isJumping = true;
			anim.SetBool("IsWalking", false);
			rigidbody.AddForce(new Vector3(0, jumpForce, 0));
		}

		rigidbody.velocity = new Vector3(speed, rigidbody.velocity.y, 0);
	}

	void OnCollisionEnter (Collision coll) {
		if(coll.collider.tag == "Ground") {
			isJumping = false;
			anim.SetBool("IsWalking", true);
		}
	}
}
