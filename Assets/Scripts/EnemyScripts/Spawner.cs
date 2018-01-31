using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform[] locations;
    public GameObject[] prefab;
    public GameObject[] clone;
    private int i = 0;
    [Space(15)]
    public GameObject[] obj;
    public int enemyLimit = 5;
	public Visualizer visualizer;
	private float audiolength;
	private void Start()
    {
		audiolength = visualizer.audioClip.length/10;
        StartCoroutine(randomSpawn());
    }

    void Update()
    {
        obj = GameObject.FindGameObjectsWithTag("Enemy");
        if(obj.Length == enemyLimit)
        {
            Debug.Log("LIMIT BREAK");
        }

    }
    IEnumerator randomSpawn()
    {
        
        if (obj.Length < enemyLimit)
        {
            for (i = 0; i < audiolength; i++)
            {
            
                int random = Random.Range(0, locations.Length);

                yield return new WaitForSeconds(3);
                clone[0] = Instantiate(prefab[0], locations[random].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            }
        }
        else
        {
            yield break;
        }
        
    
    }
	void OnGUI()
	{
		string stringToEdit = audiolength.ToString();
		stringToEdit = GUI.TextField(new Rect(1000, 100, 50, 25), stringToEdit, 25);
	}
}
