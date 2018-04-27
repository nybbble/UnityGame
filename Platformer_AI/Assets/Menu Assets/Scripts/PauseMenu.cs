using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;

    private bool paused = false;
    private GameObject Bg;

    private void Awake()
    {
        Bg = GameObject.FindGameObjectWithTag("music");
    }

    void Start()
    {
        PauseUI.SetActive(false);
    }

     void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            paused = !paused;
        }

        if(paused)
        {

            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {

            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }



    }

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    

    public void GoMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
        

    }

    public void PauseSoundOnOff()
    {
        if (Bg.GetComponent<AudioSource>().mute == false)
        {
            Bg.GetComponent<AudioSource>().mute = true;
        }
        else if (Bg.GetComponent<AudioSource>().mute == true)
        {
            Bg.GetComponent<AudioSource>().mute = false;
        }

    }


}
