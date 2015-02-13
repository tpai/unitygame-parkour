using SimpleJSON;
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
				CheckScore (score);
			}
			else {
				FB.Login(
					"email,publish_actions,user_friends", 
					delegate(FBResult r) {
						if(FB.IsLoggedIn) {
							CheckScore (score);
						}
					}
				);
			}
		}
	}

	void Show (bool show) {
		anim.SetBool("show", show);
	}

	void CheckScore (string score) {
		int oldScore = 0;

		FB.API(
			"/"+FB.UserId+"/scores", 
			Facebook.HttpMethod.GET, 
			delegate(FBResult r) {
				var json = JSON.Parse(r.Text);
				oldScore = json["data"][0]["score"].AsInt;
				if(int.Parse(score) > oldScore) {
					UpdateScore (score);
				}
			}
		);
	}

	void UpdateScore (string score) {
		var query = new Dictionary<string, string>();
		query["score"] = score;

		FB.API(
			"/"+FB.UserId+"/scores", 
			Facebook.HttpMethod.POST, 
				delegate(FBResult r) {
				Debug.Log (r.Error);
			},
			query
		);
	}
}
