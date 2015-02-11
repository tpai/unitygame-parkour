using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ResultPanel : MonoBehaviour {
	
	Timer timer;
	Animator anim;
	Transform mileage;
	bool showing = false;

	void Start () {
		timer = GameObject.Find ("Timer").GetComponent<Timer> ();
		mileage = transform.Find ("Mileage");
		anim = GetComponent<Animator> ();
	}
	
	void Update () {
		if(!showing && timer.stop == true) {
			showing = true;
			this.Show (true);
			string score = timer.nowTime.ToString("F0");
			mileage.GetComponent<Text>().text = score+"m";

			if(FB.IsLoggedIn) {
				UpdateScore (score);
			}
			else {
				FB.Login(
					"email,publish_actions,user_friends", 
					delegate(FBResult r) {
						if(FB.IsLoggedIn) {
							UpdateScore (score);
						}
					}
				);
			}
		}
	}

	void Show (bool show) {
		anim.SetBool("show", show);
	}

	void UpdateScore (string score) {
		var query = new Dictionary<string, string>();
		query["score"] = score;
		
		FB.API(
			"/me/scores", 
			Facebook.HttpMethod.POST, 
			delegate(FBResult r) {
				Debug.Log (r.Error);
			},
			query
		);
	}
}
