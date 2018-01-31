using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    public  void LoadLevelPicker()
    {
        SceneManager.LoadScene("levelPicker");
    }
	public  void LoadOptions()
	{
		SceneManager.LoadScene("options");
	}
}
