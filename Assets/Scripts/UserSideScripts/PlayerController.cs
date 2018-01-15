using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float power;
    public float acceleration;
    public Rigidbody2D rb2D;
    public float speed;


    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        if (Input.GetKey("w"))
        {
            power = power + (power * acceleration * Time.deltaTime);
            
            rb2D.AddForce(transform.up * power);
        } else if(Input.GetKey("s"))
        {
            power = power + (power * acceleration * Time.deltaTime);

            rb2D.AddForce(-transform.up * power);
        }
        if (Input.GetKey("d"))
        {

            rb2D.MoveRotation(rb2D.rotation + speed * Time.fixedDeltaTime * -1);
        } else if (Input.GetKey("a"))
        {
            rb2D.MoveRotation(rb2D.rotation + speed * Time.fixedDeltaTime * 1);
        }
    }
}
