using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public GameObject listRoom;
    public GameObject qr;
    public GameObject scrollView;
    public GameObject selectView;
    public GameObject roomImg;
    public Sprite[] temaSprite;
    public GameObject[] keywordsTema;
    
    
    public InputField titleField;
    public InputField commentField;

    public GameObject titleText;
    public GameObject commentText;
    public GameObject numberText;

    // Start is called before the first frame update
    void Start()
    {
        listRoom.SetActive(false);
        selectView.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(qrOn && Input.anyKey)
        {
            qrOn = false;
            SceneManager.LoadScene("MainScene");
            qr.SetActive(false);
        }
    }


    #region -- 팝업창 UI --

    //bool makingRoom = false;
    public void MakeRoomScene()
    {
        //makingRoom = true;
        //SceneManager.LoadScene("03. SelectScene");
        scrollView.SetActive(false);
        selectView.SetActive(true);
        titleField.text = "";
        commentField.text = "";
    }

    public void CompletMakeRoom()
    {
        //makingRoom = false;
        scrollView.SetActive(true);
        selectView.SetActive(false);
        listRoom.SetActive(true);

        //titleText.GetComponent<Text>().text = inputTitle;
        titleText.GetComponent<Text>().text = titleField.text;
        //commentText.GetComponent<Text>().text = inputComment;
        commentText.GetComponent<Text>().text = commentField.text;
    }

    bool qrOn = false;
    public void GameScene()
    {

        qr.SetActive(true);
        qrOn = true;
        //SceneManager.LoadScene("MainScene");
    }

    #endregion

    #region -- 테마 버튼 클릭 --
    public void BtnZoo()
    {
        roomImg.GetComponent<Image>().sprite = temaSprite[0];
        keywordsTema[0].SetActive(true);
        keywordsTema[1].SetActive(false);
        keywordsTema[2].SetActive(false);
        keywordsTema[3].SetActive(false);
    }

    public void BtnAqua()
    {
        roomImg.GetComponent<Image>().sprite = temaSprite[1];
        keywordsTema[0].SetActive(false);
        keywordsTema[1].SetActive(true);
        keywordsTema[2].SetActive(false);
        keywordsTema[3].SetActive(false);
    }
    public void BtnVehicle()
    {
        roomImg.GetComponent<Image>().sprite = temaSprite[2];
        keywordsTema[0].SetActive(false);
        keywordsTema[1].SetActive(false);
        keywordsTema[2].SetActive(true);
        keywordsTema[3].SetActive(false);
    }
    public void BtnFood()
    {
        roomImg.GetComponent<Image>().sprite = temaSprite[3];
        keywordsTema[0].SetActive(false);
        keywordsTema[1].SetActive(false);
        keywordsTema[2].SetActive(false);
        keywordsTema[3].SetActive(true);
    }
    #endregion


}
