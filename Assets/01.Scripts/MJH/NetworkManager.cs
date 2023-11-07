using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class NetworkManager : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        //PhotonNetwork.JoinLobby();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        ConnectToPhotonMasterServer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            PhotonNetwork.NickName = "플레이어";
            PhotonNetwork.JoinLobby();
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
        print(nameof(OnJoinedLobby));

        Debug.Log("로비 접속 완료");
        PhotonNetwork.LoadLevel("Lobby");
    }

    
}
