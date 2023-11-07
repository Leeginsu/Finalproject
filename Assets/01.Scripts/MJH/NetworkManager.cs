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
            PhotonNetwork.NickName = "�÷��̾�";
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
        Debug.Log("������ ����Ǿ����ϴ�.");
        // ���⿡�� ���ϴ� ������ ������ �� �ֽ��ϴ�.

    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print(nameof(OnJoinedLobby));

        Debug.Log("�κ� ���� �Ϸ�");
        PhotonNetwork.LoadLevel("Lobby");
    }

    
}
