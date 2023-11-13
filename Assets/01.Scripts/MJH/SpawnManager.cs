using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SpawnManager : MonoBehaviourPunCallbacks
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
        //int idx = Pho11tonNetwork.CurrentRoom.PlayerCount - 1;
        //PhotonNetwork.Instantiate("TemaPlayer_Photon", trSpawnPosGroup[0].position, Quaternion.identity);
        if (Application.isMobilePlatform)
        {
            
            conUI.SetActive(true);
            print("������");
            //int idx = PhotonNetwork.CurrentRoom.PlayerCount - 1;
            //int idx = 1;

        }
        else
        {
            conUI.SetActive(false);
            PhotonNetwork.Instantiate("TemaPlayer_Photon", trSpawnPosGroup[0].position, Quaternion.identity);
        }

        
    }

    bool isOK = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("���� ���� : " + PhotonNetwork.CurrentRoom.PlayerCount);

        }
        
        
        if(PhotonNetwork.InRoom == true && isOK == false)
        {
            print("��ȯ�Ϸ�");
            PhotonNetwork.Instantiate("TemaPlayer_Photon", trSpawnPosGroup[1].position, Quaternion.identity);
            isOK = true;
        }
        


    }

}
