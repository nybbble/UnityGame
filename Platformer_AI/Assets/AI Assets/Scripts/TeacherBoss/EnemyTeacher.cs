using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyTeacher : MonoBehaviour
{

    public Transform player;
    Animator anim;

    float moveSpeed = 5f;
    float direction = 0f;

    public string state = "patrol";

    bool isTimeStarted = false;
    public bool isGrounded = false;

    float currentTime;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (state == "dead")
        {
            anim.SetBool("death", true);
            anim.SetBool("idle", false);
       
            Destroy(this);
        }

        FlipCharacterTeacherEnemy();

        if (player.gameObject.GetComponent<Player>().isBossTeacher)
        {
            if (state == "patrol")
            {
                anim.SetBool("death", false);
                anim.SetBool("idle", true);

                if (isTimeStarted == false)
                {
                    currentTime = Time.time;
                    isTimeStarted = true;

                }
                if (Time.time >= currentTime + 3f)
                {
                    isTimeStarted = false;
                    state = "descending";
                }

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), moveSpeed * Time.deltaTime);


            }

            else if (state == "ascending")
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 6f, transform.position.z), moveSpeed * Time.deltaTime);

                if (transform.position.y >= 6f)
                {
                    anim.SetBool("death", false);
                    anim.SetBool("idle", true);

                    state = "patrol";
                }

            }
            else if (state == "descending")
            {
                anim.SetBool("death", false);
                anim.SetBool("idle", true);

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -2.5f, transform.position.z), 10f * moveSpeed * Time.deltaTime);


                if (isGrounded)
                {
                    state = "ascending";
                }
            }
        }
        else
        {
            anim.SetBool("death", false);
            anim.SetBool("idle", true);
        }
        
    }

    private void FlipCharacterTeacherEnemy()
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

