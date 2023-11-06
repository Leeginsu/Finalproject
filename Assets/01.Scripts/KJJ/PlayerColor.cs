using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public GameObject normal;
    public GameObject red;
    public GameObject black;
    public GameObject blue;
    public GameObject brown;
    public GameObject green;
    public GameObject orange;
    public GameObject pink;
    public GameObject purple;
    public GameObject teal;
    public GameObject white;
    public GameObject yellow;

    private Queue<GameObject> queue = new Queue<GameObject>();
    public GameObject a;

    // Start is called before the first frame update
    void Start()
    {
        queue.Enqueue(normal);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Normal()
    {
        Queue(normal);
    }
    public void Red()
    {
        Queue(red);
    }
    public void Black()
    {
        Queue(black);
    }
    public void Blue()
    {
        Queue(blue);
    }
    public void Brown()
    {
        Queue(brown);
    }
    public void Green()
    {
        Queue(green);
    }
    public void Orange()
    {
        Queue(orange);
    }
    public void Pink()
    {
        Queue(pink);
    }
    public void Purple()
    {
        Queue(purple);
    }
    public void Teal()
    {
        Queue(teal);
    }
    public void White()
    {
        Queue(white);
    }
    public void Yellow()
    {
        Queue(yellow);
    }

    public void Queue(GameObject player)
    {
        a = queue.Peek();
        a.SetActive(false);
        queue.Dequeue();
        queue.Enqueue(player);
        player.SetActive(true);
    }
}
