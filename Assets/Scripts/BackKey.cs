using UnityEngine;
using System.Collections;

public class BackKey : MonoBehaviour {

	[SerializeField]
	Animator resultPanel, shareToFBPanel;

	int state;

	void Update () {
		if (Input.GetKey(KeyCode.Escape))
		{
			switch(CheckState ()) {
				case 0:
					Application.Quit ();
					break;
				case 2:
					state = 1;
					shareToFBPanel.SetBool("show", false);
					resultPanel.SetBool("show", true);
					break;
			}
		}
	}

	int CheckState () {
		if(resultPanel.GetBool("show"))state = 1;
		else if(shareToFBPanel.GetBool("show"))state = 2;
		else state = 0;

		return state;
	}
}
