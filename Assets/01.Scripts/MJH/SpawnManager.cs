using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SpawnManager : MonoBehaviourPunCallbacks
{

    static public SpawnManager instance;

    public Transform[] trSpawnPosGroup;
    public GameObject conUI;
    public GameObject selectUI;
    public Camera color1;
    public Camera color2;
    public GameObject qrUI;
    public GameObject picUI;

    bool isOK = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //int idx = Pho11tonNetwork.CurrentRoom.PlayerCount - 1;
        //PhotonNetwork.Instantiate("TemaPlayer_Photon", trSpawnPosGroup[0].position, Quaternion.identity);
        if (Application.isMobilePlatform || NetworkManager.instance.isMoblie)
        {
            color1.gameObject.SetActive(true);
            color2.gameObject.SetActive(true);
            selectUI.SetActive(true);
            //conUI.SetActive(true);
            print("켜져라");
            //int idx = PhotonNetwork.CurrentRoom.PlayerCount - 1;
            //int idx = 1;
            isOK = true;
            //PhotonNetwork.Instantiate("TemaPlayer_Photon", trSpawnPosGroup[1].position, Quaternion.identity);
            //if (isOK == true)
            //{
            //    if (PhotonNetwork.InRoom == true)
            //    {
            //        Invoke("SpawnPlayer", 1);
            //        isOK = false;
            //    }

            //}
        }
        else
        {
            conUI.SetActive(false);
            //PhotonNetwork.Instantiate("TemaPlayer_Photon", trSpawnPosGroup[0].position, Quaternion.identity);
        }

        
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("현재 숫자 : " + PhotonNetwork.CurrentRoom.PlayerCount);

        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            qrUI.SetActive(false);
            picUI.SetActive(true);
        }
        //if(isOK == true)
        //{
        //    if(PhotonNetwork.InRoom == true)
        //    {
        //        Invoke("SpawnPlayer", 1);
        //        isOK = false;
        //    }

        //}
        


    }

    public void BtnMainScene()
    {
        PhotonNetwork.LoadLevel("MainScene");
    }

    public void BtnSelect()
    {
        color1.gameObject.SetActive(false);
        color2.gameObject.SetActive(false);

        selectUI.SetActive(false);
        conUI.SetActive(false);
        qrUI.SetActive(false);
    }
    int idx = 0;
    void SpawnPlayer()
    {
        idx = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        print("소환완료");
        PhotonNetwork.Instantiate("TemaPlayer_Photon", trSpawnPosGroup[idx].position, Quaternion.identity);
        isOK = false;
    }

}
