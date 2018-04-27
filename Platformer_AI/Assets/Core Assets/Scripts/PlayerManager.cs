using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    public Slider healthBar;

    private Player player;
    private PauseMenu menu;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        menu = GameObject.FindGameObjectWithTag("PM").GetComponent<PauseMenu>();
    }

    private void Update()
    {
        healthBar.value = player.health;

        if (player.health <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        menu.Restart();
    }
}
