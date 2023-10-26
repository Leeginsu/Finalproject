using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class UploadDownloadManager : MonoBehaviour
{
    private string uploadURL = "http://127.0.0.1:5001/main/upload-image";
    
    public void UploadAndDownloadFBX(Texture2D userImage)
    {
        StartCoroutine(UploadDownloadCoroutine(userImage));
    }

    private IEnumerator UploadDownloadCoroutine(Texture2D userImage)
    {
        // 이미지를 바이트 배열로 변환
        byte[] imageBytes = userImage.EncodeToPNG();

        // 이미지 업로드 및 FBX 다운로드
        using (UnityWebRequest www = UnityWebRequest.Post(uploadURL, "POST"))
        {
            www.uploadHandler = new UploadHandlerRaw(imageBytes);
            www.uploadHandler.contentType = "image/png";
            www.downloadHandler = new DownloadHandlerBuffer();

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Image uploaded! Downloading FBX...");

                // FBX 파일로 저장
                string fbxPath = Path.Combine(Application.persistentDataPath, "downloadedModel.fbx");
                File.WriteAllBytes(fbxPath, www.downloadHandler.data);
                Debug.Log($"FBX saved at: {fbxPath}");

                // 여기서 FBX 파일을 로드 및 활용
            }
        }
    }
}
