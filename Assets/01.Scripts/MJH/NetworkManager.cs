using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager instance;
    private void Awake()
    {
        instance = this;
        //PhotonNetwork.JoinLobby();
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

        ConnectToPhotonMasterServer();
    }

    bool start = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && start == true)
        {
            PhotonNetwork.NickName = "플레이어";

            PhotonNetwork.JoinLobby();
            start = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            PhotonNetwork.LoadLevel("MainScene");
            //if (PhotonNetwork.IsMasterClient)
            //{
            //    PhotonNetwork.AutomaticallySyncScene = true;
            //}

            //if (LobbyManager.instance.maxPlayers == PhotonNetwork.CurrentRoom.PlayerCount)
            //{
            //    print("입장");

            //    PhotonNetwork.LoadLevel("MainScene");
            //}
        }
    }

    private void ConnectToPhotonMasterServer()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("서버에 연결되었습니다.");
        // 여기에서 원하는 로직을 수행할 수 있습니다.

    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        //PhotonNetwork.AutomaticallySyncScene = true;
        print(nameof(OnJoinedLobby));

        Debug.Log("로비 접속 완료");

        if (Application.isMobilePlatform)
        {
            PhotonNetwork.LoadLevel("04. ControllerScene_Mobile");
        }
        else
        {
            PhotonNetwork.LoadLevel("Lobby");
        }

    }


}
