using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySchool : MonoBehaviour {
    
    private Transform player;

    Animator anim;

    float moveSpeed = 3f;
    float direction = 0f;
    float currentTime;
    bool isTimeStarted = false;
    public string state = "patrol";


    void Start()
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
            anim.SetBool("punch", false);
            anim.SetBool("walking", false);

            Destroy(gameObject.GetComponent<Rigidbody>());
            Destroy(gameObject.GetComponent<CapsuleCollider>());
            Destroy(this);
        }
        
        else if (state == "patrol")
        {
            direction = player.position.x - transform.position.x;

            //Debug.Log(Math.Abs(direction));

            if (Math.Abs(direction) <= 3f)
            {
                anim.SetBool("death", false);
                anim.SetBool("walking", false);
                anim.SetBool("idle", false);
                anim.SetBool("punch", true);

                state = "fighting";

            }
            else if(Math.Abs(direction) >= 9f)
            {
                anim.SetBool("death", false);
                anim.SetBool("idle", true);
                anim.SetBool("walking", false);
                anim.SetBool("punch", false);

            }
            else if (Math.Abs(direction) < 9f && Math.Abs(direction) > 3f)
            {
                anim.SetBool("death", false);
                anim.SetBool("punch", false);
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
            if (Time.time >= currentTime + 1f)
            {
                player.gameObject.GetComponent<Player>().health -= 10;
                isTimeStarted = false;
            }

            if (Math.Abs(direction) < 9f && Math.Abs(direction) > 3f)
            {
                anim.SetBool("death", false);
                anim.SetBool("walking", true);
                anim.SetBool("idle", false);
                anim.SetBool("punch", false);

                state = "patrol";
            }

            else if (Math.Abs(direction) <= 3f)
            {
                anim.SetBool("death", false);
                anim.SetBool("walking", false);
                anim.SetBool("idle", false);
                anim.SetBool("punch", true);
            }
        }

        FlipCharacterSchoolEnemy();
    }

    private void FlipCharacterSchoolEnemy()
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
