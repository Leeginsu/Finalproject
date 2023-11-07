using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using System;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    static public LobbyManager instance;

    public GameObject listRoom;
    public GameObject qr;
    public GameObject lobbyView;
    public GameObject scrollView;
    public GameObject selectView;
    //public GameObject roomImg;
    Sprite roomImg;
    public Sprite[] temaSprite;
    public GameObject[] keywordsTema;
    public Dropdown numberDropdown;
    public Toggle[] levelToggle;
    
    public InputField titleField;
    public InputField commentField;

    //public GameObject titleText;
    //public GameObject commentText;
    //public GameObject numberText;
    public int maxPlayers = 0;
    //int curPlayers = 0;

    public Transform[] readyPlayer;

   

    //Dictionary<string, RoomInfo> dicRoomInfo = new Dictionary<string, RoomInfo>();

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        

        //listRoom.SetActive(false);
        selectView.SetActive(false);

        levelToggle[0].isOn = false;
        levelToggle[1].isOn = false;
        levelToggle[2].isOn = false;

        
    }

    bool isOpen = false;
    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            if(qrOn == true)
            {
                qrOn = false;
                //curPlayers++;
                //numberText.GetComponent<Text>().text = curPlayers + " / " + maxPlayers;
                //SceneManager.LoadScene("MainScene");
                //SceneManager.LoadScene("MainScene");
                PhotonNetwork.LoadLevel("MainScene");
                qr.SetActive(false);
            }
            
        }

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    if (curPlayers < maxPlayers)
        //    {
        //        curPlayers++;
        //        numberText.GetComponent<Text>().text = curPlayers + " / " + maxPlayers;
        //    }
        //    else
        //    {
        //        roomOptions.IsOpen = false;
        //    }
        //}


        if (levelToggle[0].isOn == true)
        {
            levelToggle[1].isOn = false;
            levelToggle[2].isOn = false;
        }
        else if (levelToggle[1].isOn == true)
        {
            levelToggle[0].isOn = false;
            levelToggle[2].isOn = false;
        }
        else if (levelToggle[2].isOn == true)
        {
            levelToggle[0].isOn = false;
            levelToggle[1].isOn = false;
        }


        if (isOpen == true)
        {
            print(numberDropdown.value);
            print(PhotonNetwork.CurrentRoom.PlayerCount);
            if (numberDropdown.value == PhotonNetwork.CurrentRoom.PlayerCount)
            {
                PhotonNetwork.LoadLevel("MainScene");
                isOpen = false;
            }
        }
        
    }


    public RectTransform rtContent;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        print("호출");
        base.OnRoomListUpdate(roomList);

        for (int i = 0; i < roomList.Count; i++)
        {
            GameObject goRoomItem = Instantiate(listRoom, rtContent);

            RoomItem roomItem = goRoomItem.GetComponent<RoomItem>();

            //roomItem.SetInfo(roomList[i]);

            int tema = (int)(roomList[i].CustomProperties["tema"]);
            string comment = roomList[i].CustomProperties["comment"].ToString();
            roomItem.SetInfo(temaSprite[tema], roomList[i].Name, comment, roomList[i].PlayerCount, roomList[i].MaxPlayers);
        }

    }

    private void UpdateRoomList(List<RoomInfo> roomList)
    {
        if(roomList != null)
        {

        }
    }

    #region -- 팝업창 UI --

    //bool makingRoom = false;
    public void MakeRoomScene()
    {
        //makingRoom = true;
        //SceneManager.LoadScene("03. SelectScene");
        lobbyView.SetActive(false);
        scrollView.SetActive(false);
        selectView.SetActive(true);
        titleField.text = "";
        commentField.text = "";
    }


    RoomOptions roomOptions;
    public void CompletMakeRoom()
    {
        //makingRoom = false;
        scrollView.SetActive(false);
        selectView.SetActive(false);
        lobbyView.SetActive(false);
        //listRoom.SetActive(true);

        //titleText.GetComponent<Text>().text = inputTitle;
        //titleText.GetComponent<Text>().text = titleField.text;
        //commentText.GetComponent<Text>().text = inputComment;
        //commentText.GetComponent<Text>().text = commentField.text;


        NumberSelect();
        LevelSelect();

        roomOptions = new RoomOptions
        {
            MaxPlayers = maxPlayers,
            IsVisible = true,
            IsOpen = true
            
        };

        ExitGames.Client.Photon.Hashtable customOption = new ExitGames.Client.Photon.Hashtable();
        customOption["tema"] = temaNumber;
        customOption["comment"] = commentField.text;
        roomOptions.CustomRoomProperties = customOption;

        roomOptions.CustomRoomPropertiesForLobby = new string[] { "tema", "comment" };

        PhotonNetwork.CreateRoom(titleField.text, roomOptions);
        print("방 생성 완료");
        isOpen = true;
        //GameScene();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print("방 생성 실패 : " + message);
    }

    public void GameScene(string titleText)
    {

        
        //SceneManager.LoadScene("MainScene");
        //PhotonNetwork.JoinRoom(titleField.text);
        PhotonNetwork.JoinRoom(titleText);

        
    }

    

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        
        print("방 입장 완료");
        
        qr.SetActive(true);
        qrOn = true;

        int idx = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        //int idx = 1;

        PhotonNetwork.Instantiate("Player_Photon", readyPlayer[idx].position, Quaternion.identity);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print("방 입장 실패 : " + message);
    }

    void NumberSelect()
    {
        if (numberDropdown.value == 0)
        {
            maxPlayers = 2;
            //numberText.GetComponent<Text>().text = curPlayers + " / " + maxPlayers;
        }
        if (numberDropdown.value == 1)
        {
            maxPlayers = 3;
            //numberText.GetComponent<Text>().text = curPlayers + " / " + maxPlayers;
        }
        if (numberDropdown.value == 2)
        {
            maxPlayers = 4;
            //numberText.GetComponent<Text>().text = curPlayers + " / " + maxPlayers;
        }
        if (numberDropdown.value == 3)
        {
            maxPlayers = 5;
            //numberText.GetComponent<Text>().text = curPlayers + " / " + maxPlayers;
        }
        if (numberDropdown.value == 4)
        {
            maxPlayers = 6;
            //numberText.GetComponent<Text>().text = curPlayers + " / " + maxPlayers;
        }
    }

    void LevelSelect()
    {
        if (levelToggle[0].isOn == true)
        {
            //초급
            DifficultyManager.instance.easy = true;
            DifficultyManager.instance.normal = false;
            DifficultyManager.instance.normal = false;
        }
        if (levelToggle[1].isOn == true)
        {
            //중급
            DifficultyManager.instance.easy = false;
            DifficultyManager.instance.normal = true;
            DifficultyManager.instance.hard = false;
        }
        if (levelToggle[2].isOn == true)
        {
            //고급
            DifficultyManager.instance.easy = false;
            DifficultyManager.instance.normal = false;
            DifficultyManager.instance.hard = true;
        }
    }

    bool qrOn = false;




    #endregion

    #region -- 테마 버튼 클릭 --

    int temaNumber;
    public void BtnZoo()
    {
        temaNumber = 0;
        //roomImg.GetComponent<Image>().sprite = temaSprite[temaNumber];
        roomImg = temaSprite[temaNumber];
        keywordsTema[0].SetActive(true);
        keywordsTema[1].SetActive(false);
        keywordsTema[2].SetActive(false);
        keywordsTema[3].SetActive(false);
    }

    public void BtnAqua()
    {
        temaNumber = 1;
        //roomImg.GetComponent<Image>().sprite = temaSprite[temaNumber];
        roomImg = temaSprite[temaNumber];
        keywordsTema[0].SetActive(false);
        keywordsTema[1].SetActive(true);
        keywordsTema[2].SetActive(false);
        keywordsTema[3].SetActive(false);
    }
    public void BtnVehicle()
    {
        temaNumber = 2;
        //roomImg.GetComponent<Image>().sprite = temaSprite[temaNumber];
        roomImg = temaSprite[temaNumber];
        keywordsTema[0].SetActive(false);
        keywordsTema[1].SetActive(false);
        keywordsTema[2].SetActive(true);
        keywordsTema[3].SetActive(false);
    }
    public void BtnFood()
    {
        temaNumber = 3;
        //roomImg.GetComponent<Image>().sprite = temaSprite[temaNumber];
        roomImg = temaSprite[temaNumber];
        keywordsTema[0].SetActive(false);
        keywordsTema[1].SetActive(false);
        keywordsTema[2].SetActive(false);
        keywordsTema[3].SetActive(true);
    }
    #endregion

    public void BtnMainLobby()
    {
        lobbyView.SetActive(true);
        scrollView.SetActive(false);
        selectView.SetActive(false);
    }

    public void BtnRoomList()
    {
        lobbyView.SetActive(false);
        scrollView.SetActive(true);
        selectView.SetActive(false);
    }

}
