using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    void LoadLevelPicker()
    {
        SceneManager.LoadScene("levelPicker");
    }
	void LoadOptions()
	{
		SceneManager.LoadScene("options");
	}
}
