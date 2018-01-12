using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class LevelPicker: MonoBehaviour {
    public GameObject[] level;
    public int choosed = 1;
    public Button NextButton;
    public Button BackButton;
    public Animator anim;
	private UnityAction<int> m_MyFirstAction;

	// Use this for initialization
	void Start () {
        level = GameObject.FindGameObjectsWithTag("LevelPick");
		m_MyFirstAction += TaskOnClick;
		Button btn = NextButton.GetComponent<Button>();
        Button btn1 = BackButton.GetComponent<Button>();
		btn.onClick.AddListener(() => TaskOnClick(1));
		btn1.onClick.AddListener(() => TaskOnClick(2));
        choosed = 1;
        
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetInteger("Choosed", choosed);
        PlayerPrefs.SetInt("choosed", choosed);
	}
    void TaskOnClick(int ch)
    {
		switch (ch)
		{
			case 1:
				if (choosed != level.Length - 1)
				{
					choosed++;
				}
				else
				{
					choosed = level.Length - 1;
				}
				break;
			case 2:
				if (choosed != 0)
				{
					choosed--;
				}
				else
				{
					choosed = 0;
				}
				break;
		}
		
    }
}
