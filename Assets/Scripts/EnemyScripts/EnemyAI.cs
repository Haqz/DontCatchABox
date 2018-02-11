using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
	private GameObject target;
	public float speed;
	public GameObject[] enemies;

	private void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player");
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		InvokeRepeating("destroyAfter", 6.0f, 0.3f);
		Physics2D.IgnoreLayerCollision(9, 10);
	}
	void FixedUpdate()
	{
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
		
	}
	void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			GameObject.Destroy(gameObject);
			
		}
	}
	void destroyAfter()
	{
		Destroy(gameObject);
	}
	
}