using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public Transform gunParticles;
	public LineRenderer gunLine;
	Vector3 startPos;

	void Update () {
//		Debug.DrawRay(startPos, Vector3.right * 8f, Color.green);
	}

	public void ApplyFire () {
		startPos = 
			transform.position + 
				Vector3.right * .8f + 
				Vector3.up * .5f + 
				Vector3.back * .5f;
		
		gunParticles.particleSystem.Play();

		Ray ray = new Ray(startPos, Vector3.right);
		RaycastHit hit;
		
		if(Physics.Raycast(ray, out hit, 8f)) {
			if(hit.transform.tag == "Enemy") {
				hit.transform.SendMessage("KillByPlayer", hit.point);
			}
		}
	}
}
