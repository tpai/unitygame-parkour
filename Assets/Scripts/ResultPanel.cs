using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ResultPanel : MonoBehaviour {
	
	Timer timer;
	Animator anim;
	Transform mileage;
	[SerializeField]
	Transform leaderboard;
	[SerializeField]
	Transform sharetofb;
	bool showing = false;

	void Start () {
		timer = GameObject.Find ("Timer").GetComponent<Timer> ();
		mileage = transform.Find ("Mileage");
		anim = GetComponent<Animator> ();

		if(PlayerPrefs.GetString("topScore") == "") { 
			PlayerPrefs.SetString("topScore", "0");
		}
	}
	
	void Update () {
		if(!showing && timer.stop == true) {
			showing = true;
			this.Show (true);
			string score = timer.nowTime.ToString("F0");
			mileage.GetComponent<Text>().text = score+"m";

			int oldScore = int.Parse(PlayerPrefs.GetString("topScore"));
			int newScore = int.Parse(score);
			if(newScore > oldScore) {
				PlayerPrefs.SetString("nowScore", score);
			}
		}
	}

	void Show (bool show) {
		anim.SetBool("show", show);

		if(!Internet.IsAvailable ()) {
			leaderboard.GetComponent<Button>().interactable = false;
			leaderboard.transform.Find ("Text").GetComponent<Text>().text = "No Wifi";
			sharetofb.GetComponent<Button>().interactable = false;
			sharetofb.transform.Find ("Text").GetComponent<Text>().text = "No Wifi";
		}
		else {
			leaderboard.GetComponent<Button>().interactable = true;
			leaderboard.transform.Find ("Text").GetComponent<Text>().text = "Leaderboard";
			sharetofb.GetComponent<Button>().interactable = true;
			sharetofb.transform.Find ("Text").GetComponent<Text>().text = "Share To FB";
		}
	}
}
