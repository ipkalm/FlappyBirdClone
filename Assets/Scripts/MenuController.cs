using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject playButton;
    public GameObject muteButton;
    public GameObject menu;
    public GameObject ok;

    public AudioSource bgMusic;

    // Use this for initialization
    void Start()
    {

    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void GetOptions()
    {
        playButton.SetActive(false);
        muteButton.SetActive(true);
        menu.SetActive(false);
        ok.SetActive(true);
    }

    public void OkOptions()
    {
        playButton.SetActive(true);
        muteButton.SetActive(false);
        menu.SetActive(true);
        ok.SetActive(false);
    }

    public void SoundMute()
    {
        if (bgMusic == null)
        {
            bgMusic = GameObject.FindGameObjectWithTag("BGM").GetComponentInChildren<AudioSource>();
        }
        if (bgMusic.mute)
        {
            bgMusic.mute = false;
            muteButton.GetComponentInChildren<Text>().text = "Mute";
            PlayerPrefs.SetInt("mute", 0);
        }
        else
        {
            bgMusic.mute = true;
            muteButton.GetComponentInChildren<Text>().text = "Unmute";
            PlayerPrefs.SetInt("mute", 1);
        }
    }
}
