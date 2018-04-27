using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMother : MonoBehaviour
{
   
    public Transform player;
    Animator anim;

    float moveSpeed = 4f;
    float direction = 0f;
    float currentTime;
    bool isTimeStarted = false;

    public string state = "patrol";

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }


    void Update()
    {

        if (state == "patrol")
        {
            direction = player.position.x - transform.position.x;

            Debug.Log(Math.Abs(direction));
            if (!player.gameObject.GetComponent<Player>().isBossMother)
            {

                anim.SetBool("idle", true);
                anim.SetBool("walking", false);
                anim.SetBool("attacking", false);

            }

            if (Math.Abs(direction) <= 3f)
            {
                anim.SetBool("walking", false);
                anim.SetBool("idle", false);
                anim.SetBool("attacking", true);

                state = "fighting";

            }
            
            else if (player.gameObject.GetComponent<Player>().isBossMother && Math.Abs(direction) > 3f)
            {
                anim.SetBool("attacking", false);
                anim.SetBool("idle", false);
                anim.SetBool("walking", true);

                transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
            }
        }

        else if (state == "fighting")
        {
            direction = player.position.x - transform.position.x;

            if (!isTimeStarted)
            {
                currentTime = Time.time;
                isTimeStarted = true;
            }
            if (Time.time >= currentTime + 2f)
            {
                player.gameObject.GetComponent<Player>().health -= 15;
                isTimeStarted = false;
            }

            if (Math.Abs(direction) > 3f)
            {
                anim.SetBool("walking", true);
                anim.SetBool("idle", false);
                anim.SetBool("attacking", false);

                state = "patrol";
            }

            else if (Math.Abs(direction) <= 3f)
            {
                anim.SetBool("walking", false);
                anim.SetBool("idle", false);
                anim.SetBool("attacking", true);
            }
        }

        FlipCharacterMotherEnemy();
    }

    private void FlipCharacterMotherEnemy()
    {
        if (direction < -0.1f)
        {
            //transform.localScale = new Vector3(-1f, 1f, 1f);
            transform.eulerAngles = new Vector3(0f, -90f);
        }

        else if (direction > 0.1f)
        {
            //transform.localScale = new Vector3(1f, 1f, 1f);
            transform.eulerAngles = new Vector3(0f, 90f);
        }
    }
}

   

