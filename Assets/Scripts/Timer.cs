using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public bool stop = false;
	public float nowTime = 0;

	void Update () {
		if(stop == false) {
			nowTime += Time.deltaTime;
			GetComponent<Text> ().text = nowTime.ToString("F1")+"m";
		}
	}
}