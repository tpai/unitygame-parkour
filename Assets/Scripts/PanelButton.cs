using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelButton : MonoBehaviour {

	Animator resultPanel_anim, shareToFBPanel_anim;

	void Start () {
		resultPanel_anim = GetComponent<Animator> ();
		shareToFBPanel_anim = GameObject.Find ("ShareToFBPanel").GetComponent<Animator> ();
	}

	public void PlayAgain () {
		Application.LoadLevel (0);
	}

	public void Leaderboard () {
		Application.LoadLevel (1);
	}

	public void ShareToFB (bool show) {
		resultPanel_anim.SetBool ("show", !show);
		shareToFBPanel_anim.SetBool ("show", show);
		transform.Find ("ShareToFB").GetComponent<Button> ().interactable = false;
	}
}
