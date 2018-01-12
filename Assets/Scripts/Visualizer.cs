using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Visualizer : MonoBehaviour {
    public Color visualizerColor = Color.gray;
    public float minHeight = 15f;
    public float maxHeight = 425f;
    public float updateSenstivity = 0.5f;

    [Space(15)]
    public AudioClip audioClip;
    public bool loop = true;
    [Space(15), Range(64, 8192)]
    public int visualizerSimples = 64;

    private VisualizerCheckObject[] visualizerObj;
    private AudioSource m_audioSource;
    public float volume;

    private float[] spectrumData;


    // Use this for initialization
    void Start () {
        visualizerObj = GetComponentsInChildren<VisualizerCheckObject> ();


        if (!audioClip) return;
        m_audioSource = new GameObject("AudioSource").AddComponent<AudioSource>();
        m_audioSource.loop = loop;
        m_audioSource.clip = audioClip;

        volume = PlayerPrefs.GetFloat("volume");
        m_audioSource.volume = 0.2f;
        m_audioSource.Play();

    }
	
	// Update is called once per frame
	void Update () {

        spectrumData = m_audioSource.GetSpectrumData(visualizerSimples, 0, FFTWindow.Rectangular);
        for(int i =0; i < visualizerObj.Length; i++)
        {
            Vector2 newSize = visualizerObj[i].GetComponent<RectTransform>().rect.size;
            newSize.y = Mathf.Clamp(Mathf.Lerp(newSize.y, minHeight + (spectrumData[i] * (maxHeight - minHeight) * 5f), updateSenstivity), minHeight, maxHeight);
            visualizerObj[i].GetComponent<RectTransform>().sizeDelta = newSize;
            visualizerObj[i].GetComponent<Image>().color = visualizerColor;


        }
        
    }
}
