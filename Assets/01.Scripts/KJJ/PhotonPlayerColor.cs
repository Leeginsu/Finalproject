using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonPlayerColor : MonoBehaviourPun
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
    public GameObject spawnPos;

    public string b;
    public bool con = false;

    // Start is called before the first frame update
    void Start()
    {
        queue.Enqueue(normal);
        a = Instantiate(normal);
        a.transform.position = spawnPos.transform.position;
        a.transform.localScale = new Vector3(3, 3, 3);
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

    public Transform[] selectCharPos;
    public void Choice()
    {
        Destroy(a);
        a = queue.Peek();
        b = a.name;
        a = PhotonNetwork.Instantiate(b,selectCharPos[1].position, Quaternion.identity);
        NetworkManager.instance.playerInfo.Add(a);
        //photonView.RPC(nameof(RpcChoice), RpcTarget.MasterClient, a);
    }

    public void Queue(GameObject player)
    {
        Destroy(a);
        a = queue.Peek();
        queue.Dequeue();
        queue.Enqueue(player);
        a = Instantiate(player);
        a.transform.position = spawnPos.transform.position;
        a.transform.localScale = new Vector3(3, 3, 3);
    }

    //[PunRPC]
    //void RpcChoice(GameObject a)
    //{
    //    NetworkManager.instance.playerInfo.Add(a);
    //}
}
