using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultPanel : MonoBehaviour {

	Timer timer;
	Animator anim;
	Transform mileage;

	void Start () {
		timer = GameObject.Find ("Timer").GetComponent<Timer> ();
		mileage = transform.Find ("Mileage");
		anim = GetComponent<Animator> ();
	}
	
	void Update () {
		if(timer.stop == true) {
			mileage.GetComponent<Text>().text = timer.nowTime.ToString("F1")+"m";
			anim.SetBool("show", true);
		}
	}
}
