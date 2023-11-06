using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    public GameObject roomImg;

    public GameObject titleText;
    public GameObject commentText;
    public GameObject numberText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInfo(Sprite roomTema ,string roomName, string roomComment, int curPlayers, int maxPlayers)
    {
        roomImg.GetComponent<Image>().sprite = roomTema;

        titleText.GetComponent<Text>().text = roomName;
        commentText.GetComponent<Text>().text = roomComment;
        numberText.GetComponent<Text>().text = curPlayers + " / " + maxPlayers;


    }

    public void SetInfo(Sprite roomTema, RoomInfo info)
    {
        
    }
}
