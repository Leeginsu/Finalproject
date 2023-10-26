using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using System.IO;
using UnityEngine.Networking;


public class TakePhoto : MonoBehaviour
{
    public GameObject upLoadManger;

    public RawImage photoDisplay;
    private Texture2D screenshot; // Texture2D를 저장할 변수
    private string fileName = "screenshot.png";

    private string uploadURL = "http://192.168.0.45:5001/main/upload-image";

    private void Start()
    {

        photoDisplay.texture = null;
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        }
    }

    public void CapturePhoto()
    {
        StartCoroutine(TakeScreenshot());
        //SaveCapturedPhoto();
    }

    private IEnumerator TakeScreenshot()
    {
        yield return new WaitForEndOfFrame();

        // Capture the RawImage content
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture renderTexture = RenderTexture.GetTemporary(
            photoDisplay.mainTexture.width,
            photoDisplay.mainTexture.height
        );
        RenderTexture.active = renderTexture;

        // Copy the RawImage texture to the RenderTexture
        Graphics.Blit(photoDisplay.mainTexture, renderTexture);

        // Create a new Texture2D and read the RenderTexture
        screenshot = new Texture2D(
            photoDisplay.mainTexture.width,
            photoDisplay.mainTexture.height
        );
        screenshot.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        screenshot.Apply();

        // Display the screenshot on a UI RawImage
        photoDisplay.texture = screenshot;

        // Clean up RenderTexture
        RenderTexture.active = currentRT;
        RenderTexture.ReleaseTemporary(renderTexture);

        //UpLoadManager.uploadManager.UploadAndDownloadFBX(screenshot);
        upLoadManger.GetComponent<UpLoadManager>().UploadAndDownloadFBX(screenshot);
        print(screenshot);
        //SaveCapturedPhoto();
    }

    //public void SaveCapturedPhoto()
    //{
    //    if (screenshot != null)
    //    {
    //        byte[] bytes = screenshot.EncodeToPNG();

    //        string filePath = "C:\\Users\\user\\OneDrive\\바탕 화면\\TTT\\" + fileName;// System.IO.Path.Combine(Application.persistentDataPath, fileName);
    //        System.IO.File.WriteAllBytes(filePath, bytes);

    //        Debug.Log("이미지가 저장되었습니다. 경로: " + filePath);
    //    }
    //    else
    //    {
    //        Debug.LogWarning("저장할 이미지가 없습니다. 먼저 이미지를 캡처해야 합니다.");
    //    }
    //}

    //private void UploadAndDownloadFBX(Texture2D userImage)
    //{
    //    StartCoroutine(UploadDownloadCoroutine(userImage));
    //}

    //private IEnumerator UploadDownloadCoroutine(Texture2D userImage)
    //{
    //    byte[] imageBytes = userImage.EncodeToPNG();

    //    using (UnityWebRequest www = UnityWebRequest.Post(uploadURL, "POST"))
    //    {
    //        www.uploadHandler = new UploadHandlerRaw(imageBytes);
    //        www.uploadHandler.contentType = "image/png";
    //        www.downloadHandler = new DownloadHandlerBuffer();

    //        yield return www.SendWebRequest();

    //        if (www.result == UnityWebRequest.Result.ConnectionError)
    //        {
    //            Debug.Log(www.error);
    //        }
    //        else
    //        {
    //            Debug.Log("Image uploaded! Downloading FBX...");

    //            string fbxPath = Path.Combine(uploadURL, fileName);

    //            //string fbxPath = uploadURL + fileName;
    //            File.WriteAllBytes(fbxPath, www.downloadHandler.data);
    //            Debug.Log($"FBX saved at: {fbxPath}");

    //            // 여기서 FBX 파일을 로드 및 활용
    //        }
    //    }
    //}

}
