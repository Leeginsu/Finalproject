using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Final : MonoBehaviourPunCallbacks
{

    public GameObject correctCountUI;
    public GameObject placeMentUI;

    //public GameObject cCount;
    int correctCount; // ���� ���� ����
    Transform[] placePos; // ��ġ ���
    public GameObject correctPic1;
    public GameObject correctPic2;
    public GameObject correctPic3;

    public Text correctCountTxt;

    // Start is called before the first frame update
    void Start()
    {
        correctCount = 3;
        correctCountTxt.text = correctCount + "�� ��" + correctCount + "�� �ϼ� !";
        //if (PhotonNetwork.IsMasterClient == true)
        //{
            
        //    DontDestroyOnLoad(this.gameObject);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //correctCount = cCount.GetComponent<PreGameManager>().scoreCount;
    }

    public void BtnEnter()
    {
        correctCountUI.SetActive(false);
        placeMentUI.SetActive(true);
    }

    public void BtnPlacement()
    {
        print("��ġ�Ǿ����ϴ�.");
        placeMentUI.SetActive(false);
        //PhotonNetwork.Instantiate("",placePos[0].position,Quaternion.identity);
        correctPic1.SetActive(true);
        correctPic2.SetActive(true);
        correctPic3.SetActive(true);

    }
}
