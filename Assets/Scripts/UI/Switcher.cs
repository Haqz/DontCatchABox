using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Switcher : MonoBehaviour
{

    [SerializeField]
    private Transform levelParent;
    [SerializeField]
    private RectTransform[] levels;
    [SerializeField]
    public int currentLevel;
    [SerializeField]
    private Text levelNumberText;

	private MusicHolder[] level;
	private AudioClip music;
	public AudioSource audio;


	// Use this for initialization
	void Start()
	{
		levels = new RectTransform[levelParent.childCount];
		level = GetComponentsInChildren<MusicHolder>();
		for (int i = 0; i < levelParent.childCount; i++)
		{
			levels[i] = levelParent.GetChild(i).GetComponent<RectTransform>();
		}
		
		
		levelParent.localPosition = new Vector3(0, levelParent.localPosition.y);
		MusicUpdate(currentLevel);
	}
	public void Play()
	{
		SceneManager.LoadScene(level[currentLevel].scene.name);
	}
	public void Next()
    {
		if (currentLevel == levels.Length-1)
		{

			return;
		}
		else
		{

			currentLevel++;
			UpdateLevel();
			MusicUpdate(currentLevel);
		}
        
    }

    public void Previous()
    {
		if(currentLevel == 0)
		{
			return;
		}else
		{
			currentLevel--;
			UpdateLevel();
			MusicUpdate(currentLevel);
		}

	}
	public void MusicUpdate(int i)
	{
		music = level[i].music;
		audio.Stop();
		audio.clip = music;
		audio.Play();
	}

	private void UpdateLevel()
    {
        levelNumberText.text = currentLevel.ToString();
        StartCoroutine(Lerp(levelParent.localPosition.x, currentLevel * -levels[currentLevel].sizeDelta.x));
    }

    private IEnumerator Lerp(float startX, float targetX)
    {
        var t = 0f;
        while (t < 1)
        {
            t = t + (Time.deltaTime);

            levelParent.localPosition = new Vector3(Mathf.Lerp(startX, targetX, t), levelParent.localPosition.y);

            yield return null;

        }
    }
}
