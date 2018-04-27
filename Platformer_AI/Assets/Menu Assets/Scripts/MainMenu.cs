using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject MainUI;

    private GameObject Bg;

    private void Awake()
    {
        Bg = GameObject.FindGameObjectWithTag("music");
        Bg.GetComponent<AudioSource>().mute = false;
    }

    public void Play()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void Continue()
    {
        SceneManager.LoadScene("Level_Select");

    }

    public void Quit()
    {
        SceneManager.LoadScene("Exit");
    }

    public void SoundOff()
    {

      

        if (Bg.GetComponent<AudioSource>().mute == false)
        {
            Bg.GetComponent<AudioSource>().mute = true;
        }
        else if(Bg.GetComponent<AudioSource>().mute == true)
        {
            Bg.GetComponent<AudioSource>().mute = false;
        }




    }

    




}
