using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Controller : MonoBehaviour
{
    GameObject player;
    M_Player playerScript;

    public void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<M_Player>();
    }

    public void LRDown()
    {
        playerScript.inputLR = true;
    }
    public void LRUp()
    {
        playerScript.inputLR = false;
    }
    public void UDDown()
    {
        playerScript.inputUD = true;
    }
    public void UDUP()
    {
        playerScript.inputUD = false;
    }
}
