using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlay : MonoBehaviour
{
	private AudioClip music;
	public Switcher level;
	public MusicHolder[] songs;
	int curr;
	public AudioSource audio;

	void Update()
	{
		curr = level.currentLevel;
		music = songs[curr].music;
	}
	
}
