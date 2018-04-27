using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySchoolHurt : MonoBehaviour {
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fatal")
        {
            gameObject.GetComponent<EnemySchoolHealth>().Death();
        }
    }
}
