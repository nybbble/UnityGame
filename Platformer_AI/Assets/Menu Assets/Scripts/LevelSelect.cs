using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{

    public void Level1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_1");

    }

    public void Level2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_2");

    }

    public void BackButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main_Menu");

    }






}

