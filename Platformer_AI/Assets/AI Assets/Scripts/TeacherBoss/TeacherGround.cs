using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherGround : MonoBehaviour {

    private EnemyTeacher teacher;

    void Awake()
    {
        teacher = GetComponentInParent<EnemyTeacher>();
    }

    private void OnTriggerEnter(Collider other)
    {
        teacher.isGrounded = true;
    }

    private void OnTriggerStay(Collider other)
    {
        teacher.isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        teacher.isGrounded = false;
    }
}
