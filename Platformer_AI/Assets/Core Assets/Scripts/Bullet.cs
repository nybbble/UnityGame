using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Player player;
    private Rigidbody rb;
    private int damage = 10;
    private float speed = 15f;
    private float direct;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody>();

        if (player.transform.eulerAngles.y == 90f) direct = 1;
        else if (player.transform.eulerAngles.y == 270f) direct = -1;
        
        rb.velocity = new Vector3(speed * direct, rb.velocity.y, rb.velocity.z);
    }

    private void Update()
    {
        Destroy(gameObject, 1.75f);
    }

    private void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemySchoolHealth>().enemyScCurrentHealth -= damage;
        }

        else if (other.gameObject.tag == "BossMother")
        {
            other.gameObject.GetComponent<EnemyMotherHealth>().enemyCurrentHealth -= damage;
        }

        else if (other.gameObject.tag == "BossTeacher")
        {
            other.gameObject.GetComponent<EnemyTeacherHealth>().enemyCurrentHealth -= damage;
        }

        Destroy(gameObject);
    }
}
