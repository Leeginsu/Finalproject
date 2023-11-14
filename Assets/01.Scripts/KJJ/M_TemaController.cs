using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class M_TemaController : MonoBehaviourPun
{
    public M_TemaPlayer playerScript;

    public void Init()
    {
        playerScript = GetComponent<M_TemaPlayer>();
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
