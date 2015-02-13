using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Animator anim;
	public bool isDead = false;
	public bool isJumping = false;
	public bool jumpPressed = false;
	public bool onPlatform = false;
	public float speed = 3f;
	public float jumpForce = 800f;
	Timer timer;

	void Start () {
		anim = GetComponentInChildren<Animator>();
		anim.SetBool("IsWalking", true);
		timer = GameObject.Find ("Timer").GetComponent<Timer> ();
	}

	public void ApplyJump () {
		isJumping = true;
		jumpPressed = true;
		anim.SetBool("IsWalking", false);
	}

	void FixedUpdate () {
		if(jumpPressed) {
			jumpPressed = false;
			rigidbody.AddForce(new Vector3(0, jumpForce, 0));
		}

		if(isDead)speed = 0;
		rigidbody.velocity = new Vector3(speed, rigidbody.velocity.y, 0);
	}

	void OnCollisionEnter (Collision coll) {
		if(coll.collider.tag == "Ground") {
			isJumping = false;
			onPlatform = false;
			anim.SetBool("IsWalking", true);
		}
		else if(coll.collider.tag == "Platform") {
			isJumping = false;
			onPlatform = true;
			transform.parent = coll.transform;
			anim.SetBool("IsWalking", true);
		}
		else {
			transform.parent = null;
		}
	}

	void OnCollisionExit(Collision coll) {
		if(coll.collider.tag == "Platform") {
			isJumping = true;
			onPlatform = false;
		}
	}

	void Die () {
		isDead = true;
		timer.stop = true;
		anim.SetTrigger("Die");

		SendMessage("DieSound");
		GameObject.Find ("Camera").audio.Stop ();
	}
}
