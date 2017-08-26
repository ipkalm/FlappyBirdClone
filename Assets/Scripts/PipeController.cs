using UnityEngine;

public class PipeController : MonoBehaviour
{
    public GameObject obs1;
    public GameObject obs2;
    public GameObject obs3;
    public GameObject obs4;

    public GameObject pos;

    private int counter = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        counter = Random.Range(1, 5);

        if(collision.gameObject.tag == "obs")
        {
            switch (counter)
            {
                case 1:
                    CreatePipes(obs1);
                    break;
                case 2:
                    CreatePipes(obs2);
                    break;
                case 3:
                    CreatePipes(obs3);
                    break;
                case 4:
                    CreatePipes(obs4);
                    break;
            }
        }
        Destroy(collision.gameObject);
    }

    private void CreatePipes(GameObject obs)
    {
        Instantiate(obs, new Vector2(pos.transform.position.x, obs.transform.position.y), Quaternion.identity);
        //Destroy(obs, 2);
    }
}
