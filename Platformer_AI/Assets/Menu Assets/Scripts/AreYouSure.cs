using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreYouSure : MonoBehaviour

{
    public void No()
    {
        SceneManager.LoadScene("Main_Menu");
    }


    public void Yes()
    {
        Application.Quit();
    }
    
}
