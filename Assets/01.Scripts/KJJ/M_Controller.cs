using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Controller : MonoBehaviour
{
    public M_PhotonPlayer playerScript;

    public void Init()
    {
        playerScript = GetComponent<M_PhotonPlayer>();
    }

    public void LeftDown()
    {
        playerScript.inputLeft = true;
    }
    public void LeftUp()
    {
        playerScript.inputLeft = false;
    }

    public void RightDown()
    {
        playerScript.inputRight = true;
    }
    public void RightUp()
    {
        playerScript.inputRight = false;
    }
    public void UpDown()
    {
        playerScript.inputUp = true;
    }
    public void UpUP()
    {
        playerScript.inputUp = false;
    }
    public void DownDown()
    {
        playerScript.inputDown = true;
    }
    public void DownUP()
    {
        playerScript.inputDown = false;
    }
    public void Click()
    {
        playerScript.inputClick = true;
    }
}
