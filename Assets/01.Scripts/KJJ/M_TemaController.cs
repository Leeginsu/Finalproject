using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_TemaController : MonoBehaviour
{
    GameObject player;
    M_TemaPlayer playerScript;

    public void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<M_TemaPlayer>();
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
