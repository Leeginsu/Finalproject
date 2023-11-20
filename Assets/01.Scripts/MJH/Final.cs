using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Final : MonoBehaviourPunCallbacks
{
    public GameObject cCount;
    int correctCount; // ÆÛÁñ ¸ÂÃá °³¼ö

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient == true)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //correctCount = cCount.GetComponent<PreGameManager>().scoreCount;
    }
}
