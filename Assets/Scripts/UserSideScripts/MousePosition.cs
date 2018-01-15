using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{

    public static int zAxisPos = 0; //Static because other scripts may need to get this.
    private float yAxisPos = -5.23f;
    public float xAxisBoundry = 7.5f;
    public float speed = 10f;

    public float smoothX;
    public float smoothY;

    private Vector2 velocity;

    void Update()
    {

        Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zAxisPos - Camera.main.transform.position.z);
        mouse = Camera.main.ScreenToWorldPoint(mouse);

        float posX = Mathf.SmoothDamp(transform.position.x, mouse.x, ref velocity.x, smoothX);
        float posY = Mathf.SmoothDamp(transform.position.y, mouse.y, ref velocity.y, smoothY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}