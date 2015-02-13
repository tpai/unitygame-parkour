using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShareToFB : MonoBehaviour {
	
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

		// hide result panel
		transform.parent.SendMessage("Show", false);

		yield return new WaitForSeconds(.5f);
#if UNITY_EDITOR
		Debug.Log ("Capture screenshot and share.");
		GetComponent<Button>().interactable = false;
		transform.parent.SendMessage("Show", true);
#elif UNITY_ANDROID
		var snap = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		snap.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		snap.Apply();
		var screenshot = snap.EncodeToPNG();
		
		var wwwForm = new WWWForm();
		wwwForm.AddBinaryData("image", screenshot, "screenshot.png");
		wwwForm.AddField("message", "Check out my best record!");
		
		FB.API(
			"/me/photos",
			Facebook.HttpMethod.POST,
			delegate (FBResult r) {
				GetComponent<Button>().interactable = false;
				transform.parent.SendMessage("Show", true);
			},
			wwwForm
		);
#endif
	}
}
