using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicOptions : MonoBehaviour {

	[SerializeField]
	private Slider slider;
	public GameObject options;
	public GameObject menu;
	public static float sliderValue;
	// Use this for initialization
	void Start()
	{
		slider.value = 0.2f;
	}
	// Update is called once per frame
	void Update () {
		sliderValue = slider.value;
	}
	public void LoadPauseMenu()
	{
		options.SetActive(false);
		menu.SetActive(true);
	}
}
