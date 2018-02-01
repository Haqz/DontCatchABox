using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTime : MonoBehaviour {

	// Use this for initialization
	private float startTime;
	public Text text;
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.time - startTime;

		string minutes = ((int)t / 60).ToString();
		string seconds = (t % 60).ToString("f2");

		text.text = minutes + ":" + seconds;
	}
}
