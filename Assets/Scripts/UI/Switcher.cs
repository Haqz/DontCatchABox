using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    // Use this for initialization
    void Start()
    {
        levels = new RectTransform[levelParent.childCount];
        for (int i = 0; i < levelParent.childCount; i++)
        {
            levels[i] = levelParent.GetChild(i).GetComponent<RectTransform>();
        }

        levelParent.localPosition = new Vector3(0, levelParent.localPosition.y);

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
		}

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
