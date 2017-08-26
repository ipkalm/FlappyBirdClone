using UnityEngine;

public class Mover : MonoBehaviour
{

    public float sp = 1.5f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveObsticle();
    }

    void MoveObsticle()
    {
        transform.Translate(-sp * Time.deltaTime, 0, 0);
    }
}
