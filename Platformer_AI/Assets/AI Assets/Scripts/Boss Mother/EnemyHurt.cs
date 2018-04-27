using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fatal")
        {
            gameObject.GetComponent<EnemyMotherHealth>().Death();
        }
    }
}
