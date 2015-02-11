﻿using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Leaderboard : MonoBehaviour {

	void Start () {
		if(FB.IsLoggedIn) {
			GetAllScore ();
		}
		else {
			// 登入
			FB.Login(
				"email,publish_actions,user_friends", 
				delegate(FBResult r) {
					if(FB.IsLoggedIn) {
						GetAllScore ();
					}
				}
			);
		}
	}

	void GetAllScore () {

		string id;
		string name;
		int score;

		// 讀取分數
		FB.API(
			"/"+FB.AppId+"/scores", 
			Facebook.HttpMethod.GET, 
			delegate(FBResult r) {
				Debug.Log (r.Text);
				var json = JSON.Parse(r.Text);
				for(int i=0;i<json["data"].Count;i++) {
					Transform hero = GameObject.Find ("NO"+(i+1)).transform;
					
					id = json["data"][i]["user"]["id"];
					name = json["data"][i]["user"]["name"];
					score = json["data"][i]["score"].AsInt;
					
					hero.Find ("Name").GetComponent<Text>().text = name;
					hero.Find ("Score").GetComponent<Text>().text = score.ToString()+"m";
					StartCoroutine(GetFaceTo(hero, id));
				}
		}
		);
	}

	IEnumerator GetFaceTo (Transform hero, string id) {
		WWW www = new WWW("http://graph.facebook.com/"+id+"/picture");
		yield return www;
		if(www.error == null) {
			hero.GetComponent<RawImage>().texture = www.texture;
		}
	}

	public void BackToGame () {
		Application.LoadLevel(0);
	}
}