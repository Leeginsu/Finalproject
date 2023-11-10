using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SpawnManager : MonoBehaviour
{

    static public SpawnManager instance;

    public Transform[] trSpawnPosGroup;
    public GameObject conUI;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //int idx = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        PhotonNetwork.Instantiate("Player_Photon", trSpawnPosGroup[LobbyManager.instance.idx].position, Quaternion.identity);
        if (Application.isMobilePlatform)
        {
            conUI.SetActive(true);

            //int idx = PhotonNetwork.CurrentRoom.PlayerCount - 1;
            //int idx = 1;

            PhotonNetwork.Instantiate("Player_Photon", trSpawnPosGroup[LobbyManager.instance.idx].position, Quaternion.identity);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
