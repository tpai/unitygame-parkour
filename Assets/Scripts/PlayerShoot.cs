using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public Transform gunParticles;
	public LineRenderer gunLine;
	Vector3 startPos;

	void Update () {

		if(Input.GetButtonDown ("Fire1") && !GetComponent<PlayerMovement>().isDead) {

			startPos = transform.position + Vector3.right * .8f + Vector3.up * .5f + Vector3.back * .5f;

			gunParticles.particleSystem.Play();

			gunLine.enabled = true;
			gunLine.SetPosition(0, startPos);

			Ray ray = new Ray(startPos, Vector3.right);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, 6f)) {
				if(hit.transform.tag == "Enemy") {
					// Destroy (hit.transform.gameObject);
					hit.transform.SendMessage("KillByPlayer", hit.point);
				}
				gunLine.SetPosition(1, hit.point);
			}
			else {
				gunLine.SetPosition(1, ray.origin + ray.direction * 6f);
			}
			StartCoroutine("FireVanish");
		}
		Debug.DrawRay(startPos, Vector3.right * 6f, Color.green);
	}

	IEnumerator FireVanish () {
		yield return new WaitForSeconds (.03f);
		gunLine.enabled = false;
	}
}
