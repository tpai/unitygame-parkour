using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {
	
	void OnCollisionEnter (Collision coll) {

		GameObject other = coll.gameObject;

		if(other.tag == "Player") {
			if(transform.tag == "Enemy") {
				other.transform.position = new Vector3(
					other.transform.position.x,
					other.transform.position.y,
					-1f
				);
			}
			other.SendMessage("Die");
		}
	}

	void OnTriggerEnter (Collider other) {
		if(other.tag == "Player") {
			if(transform.tag == "Enemy") {
				other.transform.position = new Vector3(
					other.transform.position.x-1f,
					other.transform.position.y,
					other.transform.position.z
				);
			}
			other.SendMessage("Die");
			other.rigidbody.useGravity = false;
			other.rigidbody.isKinematic = true;
		}
	}
}
