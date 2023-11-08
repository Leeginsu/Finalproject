using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SpawnManager : MonoBehaviour
{

    static public SpawnManager instance;

    public Transform[] trSpawnPosGroup;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        int idx = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        //int idx = 1;

        PhotonNetwork.Instantiate("Player_Photon", trSpawnPosGroup[idx].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
