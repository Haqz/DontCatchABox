using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;
    private Vector2 velocity;
    public float smoothX;
    public float smoothY;


	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float posX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref velocity.x, smoothX);
        float posY = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref velocity.y, smoothY);
        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
