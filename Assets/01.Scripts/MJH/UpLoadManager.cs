using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;
using ICSharpCode.SharpZipLib.Zip;


public class UpLoadManager : MonoBehaviour
{
    ////public static UpLoadManager uploadManager;
    //private string fileName = "screenshot" + System.DateTime.Now.ToString("yyyyMMddHHmmss");

    //private string uploadURL = "http://192.168.0.44:5001/main/upload-image";

    //string fbxPath;

    //int maxCount;

    //private void Start()
    //{
    //    maxCount = LobbyManager.instance.maxPlayers;
    //}

    //// Start is called before the first frame update
    //public void UploadAndDownloadFBX(Texture2D userImage)
    //{
    //    StartCoroutine(UploadDownloadCoroutine(userImage));
    //}

    //private IEnumerator UploadDownloadCoroutine(Texture2D userImage)
    //{
    //    byte[] imageBytes = /*File.ReadAllBytes(Application.dataPath + "/ani.png");*/ userImage.EncodeToPNG();

    //    WWWForm form = new WWWForm();
    //    form.AddBinaryData("file", imageBytes);        

    //    using (UnityWebRequest www = UnityWebRequest.Post(uploadURL, form))
    //    {
    //        //www.uploadHandler = new UploadHandlerRaw(imageBytes);
    //        //www.uploadHandler.contentType = "image/png";
    //        //www.downloadHandler = new DownloadHandlerBuffer();



    //        yield return www.SendWebRequest();

    //        if (www.result == UnityWebRequest.Result.Success)
    //        {
    //            Debug.Log("Image uploaded! Downloading FBX...");


    //            fbxPath = Application.persistentDataPath + "/" + fileName + ".zip";
    //            print(fbxPath);

    //            ////string fbxPath = uploadURL + fileName;
    //            File.WriteAllBytes(fbxPath, www.downloadHandler.data);

    //            ExtractZip(fbxPath, Application.persistentDataPath);
    //            //Debug.Log($"FBX saved at: {fbxPath}");

    //            // ���⼭ FBX ������ �ε� �� Ȱ��
    //        }
    //        else
    //        {
    //            Debug.Log(www.error);

    //        }
    //    }
    //}

    //private void ExtractZip(string archivePath, string destinationPath)
    //{
    //    try
    //    {
    //        using (ZipInputStream zipStream = new ZipInputStream(File.OpenRead(archivePath)))
    //        {
    //            ZipEntry entry;
    //            while ((entry = zipStream.GetNextEntry()) != null)
    //            {
    //                string directoryName = Path.GetDirectoryName(entry.Name);
    //                string fileName = Path.GetFileName(entry.Name);

    //                if (directoryName.Length > 0)
    //                    Directory.CreateDirectory(Path.Combine(fbxPath, directoryName));

    //                if (fileName != string.Empty)
    //                {
    //                    using (FileStream streamWriter = File.Create(Path.Combine(fbxPath, entry.Name)))
    //                    {
    //                        int size = 2048;
    //                        byte[] data = new byte[2048];
    //                        while (true)
    //                        {
    //                            size = zipStream.Read(data, 0, data.Length);
    //                            if (size > 0)
    //                                streamWriter.Write(data, 0, size);
    //                            else
    //                                break;
    //                        }
    //                    }
    //                }
    //            }
    //        }

    //        Debug.Log("ZIP file extracted!");
    //    }
    //    catch (System.Exception ex)
    //    {
    //        Debug.LogError("Error extracting zip file: " + ex.Message);
    //    }
    //}

    private string uploadURL = "http://192.168.0.44:5001/main/upload-image";
    private string fbxPath; // ZIP ���� ���� ���
    private int maxCount; // �ִ� �÷��̾� ��

    private void Start()
    {
        maxCount = LobbyManager.instance.maxPlayers; // �ִ� �÷��̾� �� �ʱ�ȭ
    }

    public void UploadAndDownloadFBX(Texture2D userImage)
    {
        StartCoroutine(UploadDownloadCoroutine(userImage));
    }

    private IEnumerator UploadDownloadCoroutine(Texture2D userImage)
    {
        yield return StartCoroutine(UploadImageCoroutine(userImage));
    }

    private IEnumerator UploadImageCoroutine(Texture2D userImage)
    {
        byte[] imageBytes = userImage.EncodeToPNG();
        WWWForm form = new WWWForm();
        form.AddBinaryData("file", imageBytes);

        using (UnityWebRequest www = UnityWebRequest.Post(uploadURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Image uploaded successfully!");
                string fileURL = www.downloadHandler.text; // �����κ��� ������ URL�� ����
                StartCoroutine(DownloadZipCoroutine(fileURL));
            }
            else
            {
                Debug.LogError("Image upload failed: " + www.error);
            }
        }
    }

    private IEnumerator DownloadZipCoroutine(string fileURL)
    {
        fbxPath = Path.Combine(Application.persistentDataPath, "downloaded.zip"); // ZIP ���� ��� ����

        using (UnityWebRequest www = UnityWebRequest.Get(fileURL))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("ZIP downloaded successfully!");
                File.WriteAllBytes(fbxPath, www.downloadHandler.data);
                ExtractZip(fbxPath, Application.persistentDataPath);
            }
            else
            {
                Debug.LogError("ZIP download failed: " + www.error);
            }
        }
    }

    private void ExtractZip(string archivePath, string destinationPath)
    {
        try
        {
            using (ZipFile zip = new ZipFile(File.OpenRead(archivePath)))
            {
                foreach (ZipEntry entry in zip)
                {
                    if (!entry.IsFile)
                        continue;

                    string filePath = Path.Combine(destinationPath, entry.Name);
                    if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                        Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                    using (var stream = zip.GetInputStream(entry))
                    using (FileStream fileStream = File.Create(filePath))
                    {
                        stream.CopyTo(fileStream);
                    }
                }
            }

            Debug.Log("ZIP file extracted!");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error extracting zip file: " + ex.Message);
        }
    }


}
