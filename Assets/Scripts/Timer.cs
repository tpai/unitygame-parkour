using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	float nowTime = 0;

	void Update () {
		nowTime += Time.deltaTime;
		GetComponent<Text> ().text = nowTime.ToString ("F2")+"s";
	}
}