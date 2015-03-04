using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public Transform gunParticles;
	Vector3 startPos;

	public void ApplyFire () {
		startPos = 
			transform.position + 
				Vector3.right * .8f + 
				Vector3.up * .5f + 
				Vector3.back * .5f;
		
		gunParticles.GetComponent<ParticleSystem>().Play();

		Ray ray = new Ray(startPos, Vector3.right);
		RaycastHit hit;
		
		if(Physics.Raycast(ray, out hit, 8f)) {
			if(hit.transform.tag == "Enemy") {
				hit.transform.SendMessage("KillByPlayer", hit.point);
			}
		}
	}
}
