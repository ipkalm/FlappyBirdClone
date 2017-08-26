using UnityEngine;
using UnityEngine.UI;

public class Jumper : MonoBehaviour
{
    public static int score = 0;

    private Rigidbody2D bird;

    public GameObject gameOver;
    public GameObject menu;
    public GameObject pause;

    public Text scoreText;

    // Use this for initialization
    void Start()
    {
        bird = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && SceneController.IsInputEnabled)
        {
            bird.velocity = new Vector2(0, 5);
        }
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PointMaker")
        {
            score++;
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe" || collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
            score = 0;
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOver.SetActive(true);
        menu.SetActive(true);
        pause.SetActive(false);

        GameObject[] gobs = GameObject.FindGameObjectsWithTag("obs");

        foreach (var gob in gobs)
            gob.GetComponentInChildren<Mover>().sp = 0f;
    }
}
