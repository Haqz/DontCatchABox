using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioClip))]
public class CurrentPlay : MonoBehaviour
{
	private Object[] songs;
	private Object[] data;
	public AudioSource audio;
	void Start()
	{
		songs = Resources.LoadAll("Music", typeof(AudioClip));

		for(int i = 0; i < songs.Length; i++)
		{
			Debug.Log(songs[i]);
		}
		
	}
	private void FixedUpdate()
	{
		int choosed = PlayerPrefs.GetInt("choosed");
		/*switch (choosed)
		{
			case 1:
				changeMusic(songs[1].AudioClip);
				break;
			case 2:
				changeMusic(songs[2].AudioClip);
				break;
			case 3:
				changeMusic(songs[3].AudioClip);
				break;
			default:
				changeMusic(songs[1].AudioClip);
				break;
		}*/
	}
	void changeMusic(AudioClip music)
	{
		audio.Stop();
		audio.clip = music;
		audio.Play();
	}
}
