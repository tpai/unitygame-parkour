using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float xOffset = 1f;
	public float damping = 10;
	public bool lockRotation = true;
	
	void Update () {
		transform.position = Vector3.Lerp (
			transform.position,
			new Vector3(target.position.x + xOffset, transform.position.y, transform.position.z),
			Time.deltaTime * damping
		);
		
		transform.LookAt (target);

		Quaternion rot = Quaternion.identity;
		rot.eulerAngles = new Vector3(8, 0, 0);
		transform.localRotation = rot;
	}
}