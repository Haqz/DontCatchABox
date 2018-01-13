using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelPicker: MonoBehaviour {

	private const string LevelScenePrefix = "level";
	private const string LevelPickerScene = "levelPicker";
	public int SelectedLevel;

	public void LoadLevelPicker()
	{
		SceneManager.LoadScene(LevelPickerScene);
	}
	public void LoadSelectedLevel()
	{
		LoadLevel(SelectedLevel);
	}
	public void LoadLevel(int levelName)
	{

		Debug.Log(levelName);
	}
	public void NextLevel()
	{
		SelectedLevel++;
	}
	public void PreviousLevel()
	{
		SelectedLevel--;
	}
}
