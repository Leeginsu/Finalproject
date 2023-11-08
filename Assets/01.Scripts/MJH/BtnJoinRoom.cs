using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class BtnJoinRoom : MonoBehaviour
{
    GameObject lobby;

    string curRoomName;
    Transform parentF;
    // Start is called before the first frame update
    void Start()
    {
        parentF = this.transform.parent;
        this.transform.GetComponent<Button>().onClick.AddListener(GetLobbyManager);
        lobby = GameObject.Find("LobbyManager");
        curRoomName = parentF.Find("TitleFeild").GetComponent<Text>().text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void GetLobbyManager()
    {

        //GameObject.Find("LobbyManager").GetComponent<LobbyManager>().GameScene();
        lobby.GetComponent<LobbyManager>().GameScene(curRoomName);
        //lobby.GetComponent<LobbyManager>().titleField.text = this.transform.GetComponent<Button>().onClick.AddListener(()=> {PhotonNetwork.JoinRoom})
        //if (lobby.GetComponent<LobbyManager>().maxPlayers == PhotonNetwork.CurrentRoom.PlayerCount)
        //{
        //    PhotonNetwork.LoadLevel("MainScene");
        //    lobby.GetComponent<LobbyManager>().isOpen = false;
        //}
    }
}
