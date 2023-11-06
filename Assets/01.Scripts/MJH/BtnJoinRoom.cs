using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnJoinRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.GetComponent<Button>().onClick.AddListener(GetLobbyManager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetLobbyManager()
    {
        GameObject.Find("LobbyManager").GetComponent<LobbyManager>().GameScene();
    }
}
