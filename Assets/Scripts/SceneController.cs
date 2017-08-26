using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static bool IsInputEnabled { get; set; }

    private GameObject[] gobs;

    public GameObject getReady;
    public GameObject bird;
    public GameObject play;
    public GameObject pause;

    private Vector2 savedBirdVelocity;
    private float savedBirdAngularVelocity;

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Start()
    {
        IsInputEnabled = false;
        gobs = GameObject.FindGameObjectsWithTag("obs");

        foreach (var gob in gobs)
            gob.GetComponentInChildren<Mover>().sp = 0;

        bird.GetComponentInChildren<Rigidbody2D>().gravityScale = 0;
        bird.GetComponentInChildren<Animator>().enabled = false;

        Invoke("StartGame", 2);
    }

    private void StartGame()
    {
        getReady.SetActive(false);

        foreach (var gob in gobs)
            gob.GetComponentInChildren<Mover>().sp = 1.5f;

        bird.GetComponentInChildren<Rigidbody2D>().gravityScale = 1;
        bird.GetComponentInChildren<Animator>().enabled = true;

        pause.SetActive(true);

        IsInputEnabled = true;
    }

    public void PauseGame()
    {
        bird.SetActive(false);
        //Rigidbody2D rb = bird.GetComponentInChildren<Rigidbody2D>();

        //savedBirdVelocity = rb.velocity;
        //savedBirdAngularVelocity = rb.angularVelocity;
        //rb.isKinematic = false;

        gobs = GameObject.FindGameObjectsWithTag("obs");

        foreach (var gob in gobs)
            gob.GetComponentInChildren<Mover>().sp = 0;

        pause.SetActive(false);
        play.SetActive(true);
    }

    public void ResumeGame()
    {
        bird.SetActive(true);
        //Rigidbody2D rb = bird.GetComponentInChildren<Rigidbody2D>();
        //rb.isKinematic = false;
        //rb.AddForce(savedBirdVelocity, ForceMode2D.Force);
        //rb.AddTorque(savedBirdAngularVelocity, ForceMode2D.Force);

        gobs = GameObject.FindGameObjectsWithTag("obs");

        foreach (var gob in gobs)
            gob.GetComponentInChildren<Mover>().sp = 1.5f;

        pause.SetActive(true);
        play.SetActive(false);
    }
}
