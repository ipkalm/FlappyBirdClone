using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    private delegate void Escape();
    private Escape escape;

    private String curSceneName;
    
    public void Start()
    {
        curSceneName = SceneManager.GetActiveScene().name;

        if (curSceneName == "MainGame")
        {
            Screen.orientation = ScreenOrientation.Landscape;
            escape = EscapeButtonReturn;
        }
        else if (curSceneName == "Menu")
        {
            Screen.orientation = ScreenOrientation.Portrait;
            escape = EscapeButtonQuit;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escape();
        }
    }

    private void EscapeButtonQuit()
    {
        Application.Quit();
    }

    private void EscapeButtonReturn()
    {
        SceneManager.LoadScene("Menu");
    }

    //    public Camera cam;

    //    // Use this for initialization
    //    void Start()
    //    {
    //        if (PlayerPrefs.HasKey("mute"))
    //        {
    //            if (PlayerPrefs.GetInt("mute") == 0)
    //            {
    //                cam.GetComponentInChildren<AudioSource>().mute = false;
    //            }
    //            else if (PlayerPrefs.GetInt("mute") == 1)
    //            {
    //                cam.GetComponentInChildren<AudioSource>().mute = true;
    //            }
    //            else
    //            {
    //                cam.GetComponentInChildren<AudioSource>().mute = false;

    //            }
    //        }
    //    }
    //}
}