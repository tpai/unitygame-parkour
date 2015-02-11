using UnityEngine;
using System.Collections;

public class PanelButton : MonoBehaviour {

	public void PlayAgain () {
		Application.LoadLevel (0);
	}

	public void Leaderboard () {
		Application.LoadLevel (1);
	}
}
