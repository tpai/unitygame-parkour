using UnityEngine;
using System.Collections;

public class ResultPanel : MonoBehaviour {

	Timer timer;
	Animator anim;

	void Start () {
		timer = GameObject.Find ("Timer").GetComponent<Timer> ();
		anim = GetComponent<Animator> ();
	}
	
	void Update () {
		if(timer.stop == true) {
			anim.SetBool("show", true);
		}
	}
}
