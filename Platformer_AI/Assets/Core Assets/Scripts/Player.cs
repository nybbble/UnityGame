using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    
    public float moveForce = 200f;
    public float maxSpeed = 5.75f;
    public float jumpForce = 5f;
    public float dropForce = 5f;
    public bool isGrounded = false;
    public bool isBlocked = false;
    public bool isJumping = false;
    public bool isBossMother = false;
    public bool isBossTeacher = false;
    public int health = 100;
    public GameObject bulletPrefab;
    [HideInInspector]
    public GameObject bullet;
    [HideInInspector]
    public float direct;

    public enum States {run, idle}
    public States myState;

    private Animator anim;
    private PlayerManager pm;
    private Rigidbody rb;
    private Transform exitPoint;

	void Awake ()
    {
        rb = GetComponent<Rigidbody>();
        pm = GameObject.FindObjectOfType<PlayerManager>();
        exitPoint = GameObject.FindGameObjectWithTag("TriggerPoint").transform;
        anim = GetComponent<Animator>();
        myState = States.idle;
	}

    void Update ()
    {
        if (health <= 0)
        {
            Death();
        }
        
        if (myState == States.idle)
        {
            anim.SetBool("idle", true);
            anim.SetBool("run", false);
        }
        else if (myState == States.run)
        {
            anim.SetBool("idle", false);
            anim.SetBool("run", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }

        if (Input.GetKeyDown(KeyCode.L) && bullet == null)
        {
            Shoot();
        }

        FlipCharacter();
    }

    void FixedUpdate ()
    {
        direct = Input.GetAxis("Horizontal");

        if (direct != 0)
        {
            myState = States.run;

            if (direct * rb.velocity.x < maxSpeed && !isBlocked)
            {
                rb.AddForce(Vector3.right * moveForce * direct);
            }

            if (Mathf.Abs(rb.velocity.x) >= maxSpeed && !isBlocked)
            {
                rb.velocity = new Vector3(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y, rb.velocity.z);
            }
        }
        else
        {
            myState = States.idle;
        }

        if (isGrounded && isJumping)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isJumping = false;
        }
        else
        {
            isJumping = false;
        }
	}

    private void FlipCharacter()
    {
        if (direct < -0.1f)
        {
            //transform.localScale = new Vector3(-1f, 1f, 1f);
            transform.eulerAngles = new Vector3(0f, -90f);
        }

        else if (direct > 0.1f)
        {
            //transform.localScale = new Vector3(1f, 1f, 1f);
            transform.eulerAngles = new Vector3(0f, 90f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fatal")
        {
            health = 0;
        }

        else if (other.gameObject.tag == "BossGate1")
        {
            transform.position = new Vector3(100f, transform.position.y, transform.position.z);
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            isBossMother = true;
        }

        else if (other.gameObject.tag == "BossGate2")
        {
            transform.position = new Vector3(-2f, transform.position.y, transform.position.z);
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            isBossTeacher = true;
        }

        if (other.gameObject.tag == "TeacherFeet")
        {
            health -= 20;
        }
    }

    private void Shoot()
    {
        bullet = Instantiate(bulletPrefab, exitPoint.position, Quaternion.identity);
    }

    private void Death()
    {
        pm.GameOver();
    }
}
