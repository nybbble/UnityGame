using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySchoolHealth : MonoBehaviour {
    
    public int enemyScMaxHealth = 20;
    public int enemyScCurrentHealth;
    

    void Start()
    {
        SetMaxHealth();
    }

    void Update()
    {
        if (enemyScCurrentHealth <= 0)
        {
            Death();
        }
    }

    public void SetMaxHealth()
    {
        enemyScCurrentHealth = enemyScMaxHealth;
    }

    public void Death()
    {
        GetComponent<EnemySchool>().state = "dead";

        //Destroy(gameObject);
    }
}
