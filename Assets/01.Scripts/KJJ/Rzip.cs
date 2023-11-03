using System.IO;
using System.IO.Compression;
using UnityEngine;

public class Rzip : MonoBehaviour
{
    public string zipFilePath; // ���� ������ ���
    public string extractionPath; // ������ ������ ���

    private void Start()
    {
        // ������ ��ġ + �̸�
        zipFilePath = Application.dataPath + "/screenshot.zip";
        // ����Ǯ ��ġ + �����̸�
        extractionPath = Application.dataPath + "/Resources";
        // ���� Ǯ�� �Լ� ȣ��
        Unzip(zipFilePath, extractionPath);
    }

    void Unzip(string zipPath, string extractionPath)
    {
        try
        {
            // ���� ������ ������ ��ο��� ����
            ZipFile.ExtractToDirectory(zipPath, extractionPath);
            Debug.Log("���� ������ ���������� �����Ǿ����ϴ�.");
        }
        catch (IOException e)
        {
            Debug.LogError("���� ������ �����ϴ� �߿� ���� �߻�: " + e.Message);
        }
    }
}