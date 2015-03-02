using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Leaderboard : MonoBehaviour {

	void Start () {

		if(FB.IsLoggedIn) {
			CheckScore ();
		}
		else {
			FB.Login(
				"email,publish_actions,user_friends", 
				delegate(FBResult r) {
					if(FB.IsLoggedIn) {
						CheckScore ();
					}
				}
			);
		}
	}

	void CheckScore () {
		int oldScore = 0;
		int newScore = int.Parse(PlayerPrefs.GetString("nowScore"));
		
		FB.API(
			"/"+FB.UserId+"/scores", 
			Facebook.HttpMethod.GET, 
			delegate(FBResult r) {
				var json = JSON.Parse(r.Text);
				oldScore = json["data"][0]["score"].AsInt;
				if(newScore > oldScore) {
					UpdateScore (newScore.ToString());
				}
				else {
					GetAllScore ();
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
				GetAllScore ();
			},
			query
		);
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
				var json = JSON.Parse(r.Text);
				for(int i=0;i<10;i++) {
					Transform hero = GameObject.Find ("NO"+(i+1)).transform;
					if(i >= json["data"].Count)hero.gameObject.SetActive(false);
					else {
						id = json["data"][i]["user"]["id"];
						name = json["data"][i]["user"]["name"];
						score = json["data"][i]["score"].AsInt;
						
						hero.Find ("Name").GetComponent<Text>().text = name;
						hero.Find ("Score").GetComponent<Text>().text = score.ToString()+"m";
						StartCoroutine(GetFaceTo(hero, id));
					}
				}
			}
		);
	}

	IEnumerator GetFaceTo (Transform hero, string id) {
		WWW www = new WWW("http://graph.facebook.com/"+id+"/picture?width=300&height=300");
		yield return www;
		if(www.error == null) {
			hero.GetComponent<RawImage>().texture = www.texture;
		}
	}

	public void BackToGame () {
		Application.LoadLevel(0);
	}
}
