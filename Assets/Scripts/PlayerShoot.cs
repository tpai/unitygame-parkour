using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			Ray ray = new Ray(transform.position + Vector3.up * .5f, Vector3.right);
			RaycastHit hit;
			
			if(Physics.Raycast(ray, out hit, 4f)) {
				Debug.Log (hit.transform.tag);
			}
		}
		Debug.DrawRay(transform.position + Vector3.up * .5f, Vector3.right * 4f, Color.green);
	}
}
