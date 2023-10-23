using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoSceneManager : MonoBehaviour
{
    private bool canLoadScene = false;

    void Update()
    {
        if (Input.anyKey && canLoadScene)
        {
            // ���⿡ ���� ���� �̸��� �Է��մϴ�.
            string nextSceneName = "LobbyScene";
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            canLoadScene = true;
        }
    }
}
