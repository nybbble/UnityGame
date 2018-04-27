using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour {

    private bool isShot = false;
    private float speed = 15f;
    private float currentPos;

    private void Start()
    {
        currentPos = transform.position.y;
    }
    
	void FixedUpdate ()
    {
		if (isShot)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, currentPos - 25f, transform.position.z), speed * Time.deltaTime);
        }
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            isShot = true;
        }
    }
}
