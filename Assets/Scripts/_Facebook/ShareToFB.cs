using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShareToFB : MonoBehaviour {

	Animator shareToFBPanel_anim;

	void Start () {
		shareToFBPanel_anim = transform.parent.GetComponent<Animator> ();
	}

	public void ButtonClick () {
		if(FB.IsLoggedIn) {
			StartCoroutine("ApplyShare");
		}
		else {
			FB.Login(
				"email,publish_actions,user_friends", 
				delegate(FBResult r) {
					if(FB.IsLoggedIn) {
						StartCoroutine("ApplyShare");
					}
				}
			);
		}
	}

	IEnumerator ApplyShare () {
		shareToFBPanel_anim.SetBool ("show", false);
		string message = transform.parent.Find ("Message").Find ("Text").GetComponent<Text> ().text;

		yield return new WaitForSeconds(.5f);
#if UNITY_EDITOR
		Debug.Log ("Capture screenshot and share.");
		Debug.Log ("Message: "+message);
		GameObject.Find ("ResultPanel").SendMessage("ShareToFB", false);
#elif UNITY_ANDROID
		var snap = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		snap.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		snap.Apply();
		var screenshot = snap.EncodeToPNG();
		
		var wwwForm = new WWWForm();
		wwwForm.AddBinaryData("image", screenshot, "screenshot.png");
		wwwForm.AddField("message", message);
		
		FB.API(
			"/me/photos",
			Facebook.HttpMethod.POST,
			delegate (FBResult r) {
				GameObject.Find("ResultPanel").SendMessage("ShareToFB", false);
			},
			wwwForm
		);
#endif
	}
}
