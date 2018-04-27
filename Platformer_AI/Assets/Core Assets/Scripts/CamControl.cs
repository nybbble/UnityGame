using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {

    /*public float dampTime = 0.05f;
    private Vector3 velocity = Vector3.zero;*/

    private GameObject player;
    private Transform target;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update ()
    {
        if (player.GetComponent<Player>().isBossMother)
        {
            transform.position = new Vector3(126.5f, 7.5f, -37.5f);
            transform.eulerAngles = new Vector3(10f, 0f, 0f);
        }
        else if (player.GetComponent<Player>().isBossTeacher)
        {
            transform.position = new Vector3(-30f, 7.5f, -37.5f);
            transform.eulerAngles = new Vector3(10f, 0f, 0f);
        }
        else
        {
            Vector3 pos = new Vector3(player.transform.position.x, Mathf.Clamp(player.transform.position.y + 3.5f, 1f, 25f), transform.position.z);
            transform.position = pos;
        }

        /*if (target)
        {
            Vector3 point = Camera.main.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }*/
    }
}
