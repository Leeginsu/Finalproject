using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TakePhoto : MonoBehaviour
{
    // Start is called before the first frame update
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
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        // Display the screenshot on a UI RawImage
        photoDisplay.texture = screenshot;

        // Save the screenshot to the device's photo gallery
        byte[] bytes = screenshot.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.persistentDataPath + "/screenshot.png", bytes);
    }
}
