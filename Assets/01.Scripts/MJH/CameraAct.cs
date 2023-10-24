using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using ZXing;
//using ZXing.QrCode;
using Photon.Pun;
using Photon.Realtime;

public class CameraAct : MonoBehaviour
{
    public RawImage photoDisplay;

    private void Start()
    {
        photoDisplay.texture = null;
    }

    public void CapturePhoto()
    {
        StartCoroutine(TakeScreenshot());
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
        Texture2D screenshot = new Texture2D(
            photoDisplay.mainTexture.width,
            photoDisplay.mainTexture.height
        );
        screenshot.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        screenshot.Apply();

        // Display the screenshot on a UI RawImage
        photoDisplay.texture = screenshot;

        // Save the screenshot to the device's photo gallery
        byte[] bytes = screenshot.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.persistentDataPath + "/screenshot.png", bytes);

        // Clean up RenderTexture
        RenderTexture.active = currentRT;
        RenderTexture.ReleaseTemporary(renderTexture);
    }
}
