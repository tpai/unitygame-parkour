using UnityEngine;
using System.Collections;

public class FBInit : MonoBehaviour {

	private static FBInit instance = null;
	
	void Awake ()
	{
		if(instance == null){
			instance = this;
			GameObject.DontDestroyOnLoad(this.gameObject);
		}
		else {
			Destroy (gameObject);
		}
	}
	
	void Start () {
		FB.Init(
			delegate() {
				Debug.Log ("FB SDK Inited!");
			},
			delegate(bool isGameShown) {
				Time.timeScale = (!isGameShown)?0:1;
			}
		);
	}
}
