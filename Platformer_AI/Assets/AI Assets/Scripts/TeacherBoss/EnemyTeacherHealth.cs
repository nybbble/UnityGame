using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTeacherHealth : MonoBehaviour
{

    public int enemyMaxHealth = 100;
    public int enemyCurrentHealth;

  
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }


    void Update()
    {
        if (enemyCurrentHealth <= 0)
        {
            Death();
        }
    }

    public void SetMaxHealth()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    public void Death()
    {
        SceneManager.LoadScene("GameOver");
    }

}
