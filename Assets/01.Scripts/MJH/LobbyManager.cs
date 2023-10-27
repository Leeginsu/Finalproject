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
    public Dropdown numberDropdown;
    public Toggle[] levelToggle;
    
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

        levelToggle[0].isOn = false;
        levelToggle[1].isOn = false;
        levelToggle[2].isOn = false;
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


        NumberSelect();
        LevelSelect();

        

    }
    void NumberSelect()
    {
        if (numberDropdown.value == 0)
        {
            numberText.GetComponent<Text>().text = " 00 " + "/" + " 02 ";
        }
        if (numberDropdown.value == 1)
        {
            numberText.GetComponent<Text>().text = " 00 " + "/" + " 03 ";
        }
        if (numberDropdown.value == 2)
        {
            numberText.GetComponent<Text>().text = " 00 " + "/" + " 04 ";
        }
        if (numberDropdown.value == 3)
        {
            numberText.GetComponent<Text>().text = " 00 " + "/" + " 05 ";
        }
        if (numberDropdown.value == 4)
        {
            numberText.GetComponent<Text>().text = " 00 " + "/" + " 06 ";
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
