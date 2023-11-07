using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SpawnManager : MonoBehaviour
{

    static public SpawnManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate("Player_Photon", Vector3.zero, Quaternion.identity);
        SetSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform[] trSpawnPosGroup;
    void SetSpawnPos()
    {
        
    }
}
