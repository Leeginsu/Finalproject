using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;


public class TakePhoto : MonoBehaviour
{

    public RawImage photoDisplay;
    private Texture2D screenshot; // Texture2D를 저장할 변수
    private string fileName = "screenshot.png";

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

        //// Save the screenshot to the device's photo gallery
        //byte[] bytes = screenshot.EncodeToPNG();
        ////string filePath = Application.persistentDataPath + "/screenshot.png"; //추가
        ////System.IO.File.WriteAllBytes(filePath, bytes); //추가

        //string filePath = System.IO.Path.Combine(Application.persistentDataPath, fileName);
        ////System.IO.File.WriteAllBytes(Application.persistentDataPath + "/screenshot.png", bytes);

        //if (Application.platform == RuntimePlatform.Android)
        //{
        //    AndroidJavaClass mediaScanner = new AndroidJavaClass("android.media.MediaScannerConnection");
        //    AndroidJavaClass javaObject = new AndroidJavaClass("java.lang.Object");
        //    mediaScanner.CallStatic("scanFile", new AndroidJavaObject("android.content.Context",
        //        new AndroidJavaObject("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity")),
        //        new string[] { filePath }, null, javaObject);
        //}

        // Clean up RenderTexture
        RenderTexture.active = currentRT;
        RenderTexture.ReleaseTemporary(renderTexture);
        SaveCapturedPhoto();
    }

    public void SaveCapturedPhoto()
    {
        if (screenshot != null)
        {
            byte[] bytes = screenshot.EncodeToPNG();

            string filePath = "C:\\Users\\user\\OneDrive\\바탕 화면\\TTT\\" + fileName;// System.IO.Path.Combine(Application.persistentDataPath, fileName);
            System.IO.File.WriteAllBytes(filePath, bytes);

            Debug.Log("이미지가 저장되었습니다. 경로: " + filePath);
        }
        else
        {
            Debug.LogWarning("저장할 이미지가 없습니다. 먼저 이미지를 캡처해야 합니다.");
        }
    }

}
