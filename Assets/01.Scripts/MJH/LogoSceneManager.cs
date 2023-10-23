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
            // 여기에 다음 씬의 이름을 입력합니다.
            string nextSceneName = "LobbyScene";
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            canLoadScene = true;
        }
    }
}
